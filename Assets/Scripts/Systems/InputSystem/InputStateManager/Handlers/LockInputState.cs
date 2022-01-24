namespace InputStateSystem
{
    public class LockInputState : IState
    {
        public bool RequestTarget { get; }

        public LockInputState()
        {
            this.RequestTarget = true;
        }
        public void OnIdleUpdate()
        {

        }

        public void OnTargetUpdate()
        {
            
        }
    }
}