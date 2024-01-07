using System;
using System.Collections.Generic;
using Sources.Common.WindowFsm;
using Sources.Common.WindowFsm.Windows;
using Sources.Controllers.Api.Presenters;
using Sources.Controllers.Api.Services;
using Sources.Controllers.Core.Factories;
using Sources.Controllers.Core.Services;
using Sources.Controllers.Core.ViewModels;
using Sources.Controllers.Core.WindowFsms;
using Sources.Controllers.Core.WindowFsms.Windows;
using Sources.Domain.Factories;
using Sources.Infrastructure.Api.GameFsm;
using Sources.Infrastructure.Api.Services;
using Sources.Infrastructure.Api.Services.Providers;
using Sources.Infrastructure.Core.Services;
using Sources.Infrastructure.Core.Services.DI;
using Sources.Presentation.Core;
using UnityEngine;

namespace Sources.Application.CompositionRoots
{
    public sealed class GameLoopCompositionRoot : SceneCompositionRoot, ICoroutineRunner
    {
        [SerializeField] private GameLoopView _gameLoopView;
        [SerializeField] private LoseView _loseView;

        public override void Initialize(ServiceContainer serviceContainer)
        {
            IConfigurationProvider configurationProvider = serviceContainer.Single<IConfigurationProvider>();
            IPersistentDataService persistentDataService = serviceContainer.Single<IPersistentDataService>();
            IGameStateMachine gameStateMachine = serviceContainer.Single<IGameStateMachine>();
            IUpdateService updateService = serviceContainer.Single<IUpdateService>();

            IShipFactory shipFactory = new ShipFactory();
            IShipPresenterFactory shipPresenterFactory = new ShipPresenterFactory(shipFactory, configurationProvider);
            IEnemySpawner enemyEnemySpawner = new EnemySpawner(shipFactory, shipPresenterFactory, this, configurationProvider);
            ILevelProgressCounter levelProgressCounter = new LevelProgressCounter();

            IDisposeHandler sceneDisposeHandler = new GameObject(nameof(SceneDisposeHandler)).AddComponent<SceneDisposeHandler>();
          
            GameLoopService gameLoopService = new GameLoopService
            (
                shipPresenterFactory,
                enemyEnemySpawner,
                levelProgressCounter,
                configurationProvider.PlayerSpawnPosition,
                persistentDataService,
                updateService
            );

            Dictionary<Type, IWindow> windows = new Dictionary<Type, IWindow>()
            {
                [typeof(RootWindow)] = new RootWindow(),
                [typeof(GameLoopWindow)] = new GameLoopWindow(),
                [typeof(LoseWindow)] = new LoseWindow(),
            };

            IWindowFsm windowFsm = new WindowFsm<RootWindow>(windows);

            GameLoopViewModel gameLoopViewModel = new GameLoopViewModel(windowFsm, gameStateMachine, gameLoopService);

            sceneDisposeHandler.Register(gameLoopService);
            sceneDisposeHandler.Register(gameLoopViewModel);
            
            _gameLoopView.Initialize(gameLoopViewModel);
            _loseView.Initialize(gameLoopViewModel);

            gameLoopService.Start();
        }
    }
}