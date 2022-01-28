namespace InputStateSystem
{
    public class BuildingStateManager : StateManager, IBuildingStateManager
    {
        private IState _locker;

        public BuildingStateManager()
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