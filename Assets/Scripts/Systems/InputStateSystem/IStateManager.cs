using Utils.Services;

namespace InputStateSystem
{
    public interface IStateManager : IService
    {
        void PushHandler(IState handler, bool isTarget = false);

        void PopHandler(IState handler);
    }
}
