namespace InputStateSystem
{
    public interface IInputStateManager : IStateManager
    {
        public void LockInput();
        public void UnlockInput();
    }
}