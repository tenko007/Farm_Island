namespace Utils.Services
{
    public interface IServiceLocator
    {
        void RegisterService<T>(T service) where T : IService;
        T GetService<T>() where T : IService;
    }
}