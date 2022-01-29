using System;
using System.Collections;
using Foundation.MVC;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Systems.BuildingSystem
{
    public class ResourceGainerView : StructureView, IPointerClickHandler
    {
        private void Start()
        {
            StartCoroutine(NotificationWaiting()); 
        }
        
        private ResourceGainerController Controller => (ResourceGainerController) controller;
        public override void Init(BaseModel newModel)
        {
            controller = new ResourceGainerController();
            base.Init(newModel);
            ((ResourceGainerModel)newModel).LastUsedTime = DateTime.Now;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            int resourceCountGot = Controller.CollectResource(DateTime.Now);
            if (resourceCountGot < 0)
                ; // TODO Open UI Menu.
            
            if (resourceCountGot > 0)
                StartCoroutine(NotificationWaiting());
        }

        private IEnumerator NotificationWaiting()
        {
            for (;;)
            {
                if (Controller.CanBeCollected(DateTime.Now))
                {
                    Controller.ShowCollectNotification();
                    yield break;
                }

                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}