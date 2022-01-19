using System;
using System.Collections.Generic;

namespace Utils.Services
{
    public class ServiceLocator : IServiceLocator
    {
        private Dictionary<Type, object> Services = new Dictionary<Type, object>();
        
        public void RegisterService<T>(T service)
        {
            if (service == null)
                throw new NullReferenceException($"Attempt to register null as a service {typeof(T)}");
            
            if (!Services.ContainsKey(typeof(T)))
                Services.Add(typeof(T), service);
            else
                Services[typeof(T)] = service;
        }

        public T GetService<T>()
        {
            if (Services.ContainsKey(typeof(T)))
                return (T) Services[typeof(T)];
            else
                throw new KeyNotFoundException($"Service with type {typeof(T)} not registered");
        }
        
        public T TryGetService<T>()
        {
            if (Services.ContainsKey(typeof(T)))
                return (T)Services[typeof(T)];
            
            return default(T);
        }
    }
}