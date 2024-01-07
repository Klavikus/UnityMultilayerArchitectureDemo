using System;
using System.Collections.Generic;
using Sources.Infrastructure.Api.Services;
using UnityEngine;

namespace Sources.Infrastructure.Core.Services
{
    public class SceneDisposeHandler : MonoBehaviour, IDisposeHandler
    {
        private readonly HashSet<IDisposable> _disposables = new();

        public void Register(IDisposable disposable) =>
            _disposables.Add(disposable);

        public void Unregister(IDisposable disposable) =>
            _disposables.Remove(disposable);

        public void DisposeAll()
        {
            foreach (IDisposable disposable in _disposables)
                disposable.Dispose();

            Clear();
        }

        public void Clear() =>
            _disposables.Clear();

        private void OnDestroy() =>
            DisposeAll();
    }
}