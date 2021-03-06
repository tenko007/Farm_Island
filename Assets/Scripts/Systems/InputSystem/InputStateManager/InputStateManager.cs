namespace InputStateSystem
{
    public class InputStateManager : StateManager, IInputStateManager
    {
        private IState _locker;

        public InputStateManager()
        {
            this._locker = new LockInputState();
        }
        public void LockInput()
        {
            PushHandler(_locker, isTarget: true);
        }

        public void UnlockInput()
        {
            PopHandler(_locker);
        }
    }
}