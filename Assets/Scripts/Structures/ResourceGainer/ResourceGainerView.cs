using System;
using Foundation.MVC;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Systems.BuildingSystem
{
    public class ResourceGainerView : BaseView, IPointerClickHandler
    {
        public override void Init(BaseModel newModel)
        {
            controller = new ResourceGainerController();
            base.Init(newModel);
            ((ResourceGainerModel)newModel).LastUsedTime = DateTime.Now;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (((ResourceGainerController)controller).CollectResource(DateTime.Now) < 0)
                ; // TODO Open UI Menu.
        }

    }
}