namespace Utils.Services
{
    public static class Services
    {
        private static IServiceLocator _serviceLocator;

        public static void SetServiceLocator(IServiceLocator serviceLocator)
        {
            Services._serviceLocator = serviceLocator;
        }
        
        public static void RegisterService<T>(T service) where T : IService
        {
            _serviceLocator.RegisterService(service);
        }

        public static T GetService<T>() where T : IService
        {
            return _serviceLocator.GetService<T>();
        }
    }
}