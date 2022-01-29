using Systems.BuildingSystem;
using UnityEngine.EventSystems;
using Utils.Services;

namespace Foundation.MVC
{
    public abstract class StructureView : BaseView, IDragHandler, IBeginDragHandler
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