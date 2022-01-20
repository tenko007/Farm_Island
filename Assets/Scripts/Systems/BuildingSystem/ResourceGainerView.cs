using System;
using Foundation.MVC;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Systems.BuildingSystem
{
    public class ResourceGainerView : BaseView<ResourceGainerModel, ResourceGainerController>, IPointerClickHandler
    {
        public override void Init(ResourceGainerModel newModel)
        {
            base.Init(newModel);
            newModel.LastUsedTime = DateTime.Now;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (controller.CollectResource(DateTime.Now) < 0)
                ; // TODO Open UI Menu.
        }
    }
}