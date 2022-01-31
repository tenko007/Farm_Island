using System;
using System.Collections;
using Foundation.MVC;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Systems.BuildingSystem
{
    public class ResourceGainerView : BuildingView<ResourceGainerController>, IPointerClickHandler
    {
        private GameObject NotificationObject;
        
        public override void Init(BaseModel newModel)
        {
            controller = new ResourceGainerController();
            base.Init(newModel);
            ((ResourceGainerModel)newModel).LastUsedTime = DateTime.Now;

        }

        private void Start()
        {
            controller.OnCanBeCollected += OnCanBeCollected;
            controller.OnCollected += OnCollected;
        }

        private void OnDestroy()
        {
            controller.OnCanBeCollected -= OnCanBeCollected;
            controller.OnCollected -= OnCollected;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            int resourceCountGot = controller.CollectResource(DateTime.Now);
            if (resourceCountGot < 0)
                ; // TODO Open UI Menu.
            
        }
        
        private void OnCanBeCollected()
        {
            ShowCollectableProp();
        }

        private void ShowCollectableProp()
        {
            if (((ResourceGainerModel)Model).CollectNotificationPrefab == null)
                return;
                
            NotificationObject = GameObject.Instantiate((
                (ResourceGainerModel) Model).CollectNotificationPrefab, this.transform, false);
            NotificationObject.transform.localPosition = Vector3.up * 5;
        }
        
        private void OnCollected()
        {
            if (NotificationObject != null)
                Destroy(NotificationObject);
        }
    }
}