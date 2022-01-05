using UnityEngine;

namespace SceneStateSystem
{
    public class ExampleScript : MonoBehaviour
    {
        private SceneStateManager _sceneStateManager;

        private void Awake()
        {
            _sceneStateManager = GameManager.Instance.SceneStateManager;
        }
        
        /*
        private void Start()
        {
            _inputStateManager.PushHandler(new DummyHandler());
            _inputStateManager.PushHandler(new InputHandler());
        }

        private void Update()
        {
            _inputStateManager.Update();
        }
        */
        
#if UNITY_EDITOR
        private void OnGUI()
        {
            if (GUILayout.Button("LOCK"))
            {
                _sceneStateManager.LockInput();
                Debug.Log("LOCK!!!");
            }
            else if (GUILayout.Button("UNLOCK"))
            {
                _sceneStateManager.UnlockInput();
                Debug.Log("UNLOCK!!!");
            }
        }
#endif
    }
}