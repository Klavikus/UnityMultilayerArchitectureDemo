using System;

namespace Sources.Infrastructure.Api.Services
{
    public interface IDisposeHandler
    {
        void Register(IDisposable disposable);
        void Unregister(IDisposable disposable);
        void DisposeAll();
        void Clear();
    }
}