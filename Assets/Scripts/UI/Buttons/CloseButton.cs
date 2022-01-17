using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class CloseButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject objectToClose;
        [SerializeField] private string closeAnimationTrigger = "Close";
        [SerializeField] private float destroyDelay;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Close(objectToClose);
        }
        private void Close(GameObject objectToCloseParam)
        {
            if (objectToCloseParam == null)
                objectToCloseParam = transform.parent.gameObject;
            Animator animator = objectToCloseParam.GetComponent<Animator>();
            if (animator != null)
                animator.SetTrigger(closeAnimationTrigger);

            Destroy(objectToCloseParam, destroyDelay);
        }
    }
}