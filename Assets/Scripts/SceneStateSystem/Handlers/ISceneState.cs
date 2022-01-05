
namespace SceneStateSystem.Handlers
{
    public interface ISceneState
    {
        bool RequestTarget { get; }

        void OnIdleUpdate();
        void OnTargetUpdate();
    }
}
