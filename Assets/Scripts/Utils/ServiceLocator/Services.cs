namespace Utils.Services
{
    public static class Services
    {
        private static IServiceLocator _serviceLocator;

        public static void SetServiceLocator(IServiceLocator serviceLocator)
        {
            Services._serviceLocator = serviceLocator;
        }
        
        public static void RegisterService<T>(T service)
        {
            _serviceLocator.RegisterService(service);
        }

        public static T GetService<T>()
        {
            return _serviceLocator.GetService<T>();
        }
    }
}