using SceneStateSystem.Handlers;

namespace SceneStateSystem
{
    public interface ISceneStateManager
    {
        void PushHandler(ISceneState handler, bool isTarget = false);

        void PopHandler(ISceneState handler);
    }
}
