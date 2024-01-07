using Sources.Controllers.Api.Services;
using Sources.Infrastructure.Api.GameFsm;
using Sources.Infrastructure.Core;
using Sources.Infrastructure.Core.Services.DI;
using UnityEngine;

namespace Sources.Application
{
    public class MainMenuState : IState
    {
        private const string MainMenuScene = "MainMenu";

        private readonly SceneLoader _sceneLoader;
        private readonly ServiceContainer _serviceContainer;
        private IUpdateService _updateService;

        public MainMenuState(SceneLoader sceneLoader, ServiceContainer serviceContainer)
        {
            _sceneLoader = sceneLoader;
            _serviceContainer = serviceContainer;
        }

        public void Enter()
        {
            _updateService = _serviceContainer.Single<IUpdateService>();
            _sceneLoader.Load(MainMenuScene, OnSceneLoaded);
        }

        public void Exit()
        {
        }

        public void Update() =>
            _updateService.Update(Time.deltaTime);

        private void OnSceneLoaded() => 
            new SceneInitializer().Initialize(_serviceContainer);
    }
}