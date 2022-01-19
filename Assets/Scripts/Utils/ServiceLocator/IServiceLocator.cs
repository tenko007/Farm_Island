namespace Utils.Services
{
    public interface IServiceLocator
    {
        void RegisterService<T>(T service);
        T GetService<T>();
    }
}