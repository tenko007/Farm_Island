using System;

namespace Systems.ResourcesSystem
{
    public class ResourceSoldEvent : EventArgs
    {
        private readonly ResourceObject resourceObject;
        private readonly int totalPrice;

        public ResourceSoldEvent(ResourceObject resourceObject, int totalPrice)
        {
            this.resourceObject = resourceObject;
            this.totalPrice = totalPrice;
        }
    }
}