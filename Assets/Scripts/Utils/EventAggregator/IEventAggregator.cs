using System;
using Utils.Services;

namespace Utils.EventSystem
{
    public interface IEventAggregator : IService
    {
        void Subscribe<T>(Action<T> eventHandler) where T: EventArgs;
        void Unsubscribe<T>(Action<T> eventHandler) where T: EventArgs;
        void UnsubscribeAll<T>() where T: EventArgs;
        void Invoke<T>(T eventData) where T: EventArgs;
    }
}