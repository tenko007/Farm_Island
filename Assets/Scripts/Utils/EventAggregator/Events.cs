using System;

namespace Utils.EventSystem
{
    public static class Events
    {
        private static IEventAggregator _eventAggregator;

        public static void SetEventAggregator(IEventAggregator eventAggregator) =>
            _eventAggregator = eventAggregator;
        
        public static void Subscribe<T>(Action<T> eventHandler) where T : EventArgs =>
            _eventAggregator.Subscribe(eventHandler);

        public static void Unsubscribe<T>(Action<T> eventHandler) where T : EventArgs =>
            _eventAggregator.Unsubscribe(eventHandler);

        public static void UnsubscribeAll<T>() where T : EventArgs =>
            _eventAggregator.UnsubscribeAll<T>();

        public static void Invoke<T>(T eventData) where T : EventArgs =>
            _eventAggregator.Invoke(eventData);
    }
}