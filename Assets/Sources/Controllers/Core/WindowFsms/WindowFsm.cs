﻿using System;
using System.Collections.Generic;
using Sources.Common.WindowFsm;
using Sources.Common.WindowFsm.Windows;

namespace Sources.Controllers.Core.WindowFsms
{
    public class WindowFsm<T> : IWindowFsm
        where T : IWindow
    {
        private readonly Dictionary<Type, IWindow> _windowsByType;
        private readonly Stack<IWindow> _stack;

        private IWindow _currentWindow;

        public WindowFsm(Dictionary<Type, IWindow> windowsByType)
        {
            _windowsByType = windowsByType;
            _stack = new Stack<IWindow>();

            OpenWindow<T>();
        }

        public event Action<IWindow> Opened;
        public event Action<IWindow> Closed;

        public IWindow CurrentWindow => _currentWindow;

        public void OpenWindow<TWindow>() where TWindow : IWindow
        {
            if (_currentWindow == _windowsByType[typeof(TWindow)])
                return;

            _stack.Push(_windowsByType[typeof(TWindow)]);

            if (_currentWindow != null) 
                Closed?.Invoke(_currentWindow);

            _currentWindow = _stack.Peek();
            Opened?.Invoke(_currentWindow);
        }

        public void CloseCurrentWindow()
        {
            if (_currentWindow == null)
                return;

            _stack.Pop();
            Closed?.Invoke(_currentWindow);
            _stack.TryPeek(out _currentWindow);
            
            if (_currentWindow != null) 
                Opened?.Invoke(_currentWindow);
        }

        public void ClearHistory()
        {
            _stack.Clear();
            
            if (_currentWindow != null)
                _stack.Push(_currentWindow);
        }
    }
}