namespace Systems.ResourcesSystem
{
    public static class ResourceManager
    {
        private static IResourceActions _resourceActions;
        public static void SetResourceActions(IResourceActions actions) 
            => _resourceActions = actions;

        public static void Add(Resource resource, int count)
            => _resourceActions.Add(resource, count);

        public static void Remove(Resource resource, int count)
            => _resourceActions.Remove(resource, count);

        public static void Buy(Resource resource, int count, int price)
            => _resourceActions.Buy(resource, count, price);

        public static void Sell(Resource resource, int count, int price)
            => _resourceActions.Sell(resource, count, price);

        public static int GetCount(Resource resource)
            => _resourceActions.GetCount(resource);

        public static bool Contains(Resource resource)
            => _resourceActions.Contains(resource);
    }
}