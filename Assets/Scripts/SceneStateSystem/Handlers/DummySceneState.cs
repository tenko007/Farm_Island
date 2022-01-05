using UnityEngine;

namespace SceneStateSystem.Handlers
{
    public sealed class DummySceneState : ISceneState
    {
        public bool RequestTarget { get; }
        public void OnIdleUpdate()
        {
            Debug.Log("Dummy");
        }

        public void OnTargetUpdate()
        {
            
        }
    }
}