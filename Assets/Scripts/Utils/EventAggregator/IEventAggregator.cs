using System;

namespace Utils.EventSystem
{
    public interface IEventAggregator
    {
        void Subscribe<T>(Action<T> eventHandler) where T: EventArgs;
        void Unsubscribe<T>(Action<T> eventHandler) where T: EventArgs;
        void UnsubscribeAll<T>() where T: EventArgs;
        void Invoke<T>(T eventData) where T: EventArgs;
    }
}