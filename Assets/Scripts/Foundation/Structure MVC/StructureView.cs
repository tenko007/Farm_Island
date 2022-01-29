using Systems.BuildingSystem;
using UnityEngine.EventSystems;
using Utils.Services;

namespace Foundation.MVC
{
    public abstract class StructureView<T> : BaseView<T>, IDragHandler, IBeginDragHandler
        where T : StructureController
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            Services.GetService<IBuildingSystem>().MoveObject(this.gameObject).StartBuild();
        }

        public void OnDrag(PointerEventData eventData)
        {
            
        }
    }
}