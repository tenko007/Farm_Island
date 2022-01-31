using System;

namespace Systems.ResourcesSystem
{
    public class ResourceRemovedEvent : EventArgs
    {
        private readonly ResourceObject resourceObject;

        public ResourceRemovedEvent(ResourceObject resourceObject)
        {
            this.resourceObject = resourceObject;
        }
    }
}