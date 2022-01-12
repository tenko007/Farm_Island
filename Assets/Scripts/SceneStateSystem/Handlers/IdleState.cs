using UnityEngine;

namespace SceneStateSystem.Handlers
{
    public sealed class IdleState : IState
    {
        public bool RequestTarget { get; }
        public void OnIdleUpdate()
        {
            Debug.Log("Idle");
        }

        public void OnTargetUpdate()
        {
            
        }
    }
}