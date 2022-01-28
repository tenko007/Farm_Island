namespace InputStateSystem
{
    public interface IBuildingStateManager : IStateManager
    {
        public void LockInput();
        public void UnlockInput();
    }
}