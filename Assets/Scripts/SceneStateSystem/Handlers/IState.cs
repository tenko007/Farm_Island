
namespace SceneStateSystem.Handlers
{
    public interface IState
    {
        bool RequestTarget { get; }

        void OnIdleUpdate();
        void OnTargetUpdate();
    }
}
