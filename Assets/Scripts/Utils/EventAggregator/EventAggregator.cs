using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils.EventAggregator
{
    public class EventAggregator : IEventAggregator
    {
        public IDictionary<Type, List<Delegate>> EventHandlers { get; set; }

        public EventAggregator()
        {
            this.EventHandlers = new Dictionary<Type, List<Delegate>>();
        }

        public void Publish<T>(T eventData) where T : EventArgs
        {
            if (!EventHandlers.ContainsKey(typeof(T)))
                EventHandlers.Add(typeof(T), new List<Delegate>());
        }

        public void Subscribe<T>(Action<T> eventHandler) where T : EventArgs
        {
            if (eventHandler == null)
                throw new NullReferenceException();

            if (EventHandlers.ContainsKey(typeof(T)))
                EventHandlers[typeof(T)].Add(eventHandler);
            else
                EventHandlers.Add(typeof(T), new List<Delegate> {eventHandler});
        }
        
        public void Unsubscribe<T>(Action<T> eventHandler) where T : EventArgs
        {
            if (eventHandler == null)
                throw new NullReferenceException();

            if (EventHandlers.ContainsKey(typeof(T)))
                //if (EventHandlers[typeof(T)].Contains(eventHandler)) // TODO Do i need this line?
                EventHandlers[typeof(T)].Remove(eventHandler);
        }

        public void UnsubscribeAll<T>() where T : EventArgs
        {
            if (EventHandlers.ContainsKey(typeof(T)))
                EventHandlers[typeof(T)].Clear();
        }

        public void Invoke<T>(T eventData) where T: EventArgs
        {
            if (EventHandlers.ContainsKey(typeof(T)))
                foreach (Delegate handler in EventHandlers[typeof(T)].ToList()) // ToList for copy
                    ((Action<T>) handler)?.Invoke(eventData);
        }
    }
}