namespace Systems.ResourcesSystem
{
    public struct ResourceObject
    {
        public readonly Resource Resource;
        public readonly int Count;

        public ResourceObject(Resource resource, int count)
        {
            this.Resource = resource;
            this.Count = count;
        }
    }
}