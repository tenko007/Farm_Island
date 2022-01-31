using System;

namespace Systems.ResourcesSystem
{
    public class ResourceAddedEvent : EventArgs
    {
        private readonly ResourceObject resourceObject;

        public ResourceAddedEvent(ResourceObject resourceObject)
        {
            this.resourceObject = resourceObject;
        }
    }
}