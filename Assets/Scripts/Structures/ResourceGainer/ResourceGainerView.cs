using System;
using System.Collections;
using Foundation.MVC;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Systems.BuildingSystem
{
    public class ResourceGainerView : StructureView<ResourceGainerController>, IPointerClickHandler
    {
        public override void Init(BaseModel newModel)
        {
            controller = new ResourceGainerController();
            base.Init(newModel);
            ((ResourceGainerModel)newModel).LastUsedTime = DateTime.Now;
            controller.ShowCollectNotification += ShowCollectNotification;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            int resourceCountGot = controller.CollectResource(DateTime.Now);
            if (resourceCountGot < 0)
                ; // TODO Open UI Menu.
            
        }
        
        public void ShowCollectNotification()
        {
            Debug.Log("YOU NOW CAN COLLECT!!!");
        }
    }
}