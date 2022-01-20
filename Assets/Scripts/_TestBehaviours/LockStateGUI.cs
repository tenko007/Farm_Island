using InputStateSystem;
using UnityEngine;
using Utils.Services;

namespace _TestBehaviors
{
    public class LockStateGUI : MonoBehaviour
    {
        private IInputStateManager inputStateManager;

        private void Start()
        {
            inputStateManager = Services.GetService<IInputStateManager>();
        }
        
#if UNITY_EDITOR
        private void OnGUI()
        {
            GUILayout.Space(100);

            if (GUILayout.Button("LOCK Input"))
            {
                inputStateManager.LockInput();
            }
            else if (GUILayout.Button("UNLOCK Input"))
            {
                inputStateManager.UnlockInput();
            }
        }
#endif
    }
}