using System;
using System.Collections.Generic;
using Utils.Services;

namespace Utils.EventAggregator
{
    public interface IEventAggregator : IService
    {
        IDictionary<Type, List<Delegate>> EventHandlers { get; set; }

        void Publish<T>(T eventData) where T: EventArgs;
        void Subscribe<T>(Action<T> eventHandler) where T: EventArgs;
        void Unsubscribe<T>(Action<T> eventHandler) where T: EventArgs;
        void UnsubscribeAll<T>() where T: EventArgs;
        void Invoke<T>(T eventData) where T: EventArgs;
    }
}