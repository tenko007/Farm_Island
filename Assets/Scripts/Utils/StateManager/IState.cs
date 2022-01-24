
namespace InputStateSystem
{
    public interface IState
    {
        bool RequestTarget { get; }

        void OnIdleUpdate();
        void OnTargetUpdate();
    }
}
