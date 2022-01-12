using SceneStateSystem.Handlers;

namespace SceneStateSystem
{
    public interface IStateManager
    {
        void PushHandler(IState handler, bool isTarget = false);

        void PopHandler(IState handler);
    }
}
