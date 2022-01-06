using UnityEngine;

namespace SceneStateSystem
{
    public class LockStateGUI : MonoBehaviour
    {
        private SceneStateManager _sceneStateManager;

        private void Awake()
        {
            _sceneStateManager = GameManager.Instance.SceneStateManager;
        }
        
#if UNITY_EDITOR
        private void OnGUI()
        {
            if (GUILayout.Button("LOCK"))
            {
                _sceneStateManager.LockInput();
            }
            else if (GUILayout.Button("UNLOCK"))
            {
                _sceneStateManager.UnlockInput();
            }
        }
#endif
    }
}