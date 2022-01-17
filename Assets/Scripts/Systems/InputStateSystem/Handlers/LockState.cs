namespace InputStateSystem
{
    public class LockState : IState
    {
        public bool RequestTarget { get; }

        public LockState()
        {
            this.RequestTarget = true;
        }
        public void OnIdleUpdate()
        {

        }

        public void OnTargetUpdate()
        {
            //Debug.Log("Lock");
        }
    }
}