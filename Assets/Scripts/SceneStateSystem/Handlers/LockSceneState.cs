using UnityEngine;

namespace SceneStateSystem.Handlers
{
    public class LockSceneState : ISceneState
    {
        public bool RequestTarget { get; }

        public LockSceneState()
        {
            this.RequestTarget = true;
        }
        public void OnIdleUpdate()
        {

        }

        public void OnTargetUpdate()
        {
            Debug.Log("Lock");
        }
    }
}