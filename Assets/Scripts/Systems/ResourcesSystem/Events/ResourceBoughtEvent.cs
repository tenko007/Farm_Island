using System;

namespace Systems.ResourcesSystem
{
    public class ResourceBoughtEvent : EventArgs
    {
        private readonly ResourceObject resourceObject;
        private readonly int totalPrice;

        public ResourceBoughtEvent(ResourceObject resourceObject, int totalPrice)
        {
            this.resourceObject = resourceObject;
            this.totalPrice = totalPrice;
        }
    }
}