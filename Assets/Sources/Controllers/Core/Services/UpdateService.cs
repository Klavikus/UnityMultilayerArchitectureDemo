using System.Collections.Generic;
using Sources.Controllers.Api;
using Sources.Controllers.Api.Services;

namespace Sources.Controllers.Core.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly HashSet<IUpdatable> _updatables = new();

        public void Register(IUpdatable updatable) =>
            _updatables.Add(updatable);

        public void Unregister(IUpdatable updatable) =>
            _updatables.Remove(updatable);

        public void Update(float deltaTime)
        {
            foreach (IUpdatable updatable in _updatables)
                updatable.Update(deltaTime);
        }
    }
}