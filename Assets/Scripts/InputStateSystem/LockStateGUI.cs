using UnityEngine;
using Utils.Services;

namespace InputStateSystem
{
    public class LockStateGUI : MonoBehaviour
    {
        private InputStateManager inputStateManager;

        private void Start()
        {
            inputStateManager = ServiceLocator.GetService<InputStateManager>();
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