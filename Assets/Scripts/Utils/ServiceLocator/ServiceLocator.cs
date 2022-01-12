using System;
using System.Collections.Generic;

namespace Utils.Services
{
    public class ServiceLocator : IServiceLocator
    {
        private Dictionary<Type, IService> Services = new Dictionary<Type, IService>();
        
        public void RegisterService<T>(T service) where T : IService
        {
            if (service == null)
                throw new NullReferenceException($"Attempt to register null as a service {typeof(T)}");
            
            if (!Services.ContainsKey(typeof(T)))
                Services.Add(typeof(T), service);
            else
                Services[typeof(T)] = service;
        }

        public T GetService<T>() where T : IService
        {
            if (Services.ContainsKey(typeof(T)))
                return (T) Services[typeof(T)];
            else
                throw new KeyNotFoundException($"Service with type {typeof(T)} not registered");
        }
        
        public T TryGetService<T>() where T : IService
        {
            if (Services.ContainsKey(typeof(T)))
                return (T)Services[typeof(T)];
            
            return default(T);
        }
    }
}