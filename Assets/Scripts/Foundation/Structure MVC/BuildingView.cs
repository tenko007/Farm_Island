using System;
using Systems.BuildingSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils.Services;

namespace Foundation.MVC
{
    public abstract class BuildingView<T> : BaseView<T>, IPointerDownHandler, IPointerUpHandler
        where T : BuildingController
    {
        private float longClickDuration = 500f;
        private DateTime startTime;
        public void OnPointerDown(PointerEventData eventData)
        {
            startTime = DateTime.Now;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            int timeSpent = (DateTime.Now - startTime).Milliseconds;
            if (timeSpent >= longClickDuration) 
                StartMove();
        }
        
        private void StartMove()
        {
            Services.GetService<IBuildingSystem>().MoveObject(this.gameObject).StartBuild();
        }
    }
}