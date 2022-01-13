using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private GameObject objectToClose;
        [SerializeField] private Animator animator;
        [SerializeField] private string closeAnimationTrigger = "Close";
        [SerializeField] private float destroyDelay;
        
        private void Awake()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => Close(objectToClose));
        }

        private void Close(GameObject objectToCloseParam)
        {
            if (animator != null)
                animator.SetTrigger(closeAnimationTrigger);
            if (objectToCloseParam == null)
                objectToCloseParam = transform.parent.gameObject;
            Destroy(objectToCloseParam, destroyDelay);
        }
    }
}