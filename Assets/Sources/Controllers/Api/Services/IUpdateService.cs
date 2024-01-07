namespace Sources.Controllers.Api.Services
{
    public interface IUpdateService : IUpdatable
    {
        void Register(IUpdatable updatable);
        void Unregister(IUpdatable updatable);
    }
}