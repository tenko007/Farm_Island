using UnityEngine;

namespace SceneStateSystem
{
    public class LockStateGUI : MonoBehaviour
    {
        private InputStateManager inputStateManager;

        private void Awake()
        {
            inputStateManager = GameManager.Instance.inputStateManager;
        }
        
#if UNITY_EDITOR
        private void OnGUI()
        {
            if (GUILayout.Button("LOCK"))
            {
                inputStateManager.LockInput();
            }
            else if (GUILayout.Button("UNLOCK"))
            {
                inputStateManager.UnlockInput();
            }
        }
#endif
    }
}