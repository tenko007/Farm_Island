namespace Systems.ResourcesSystem
{
    public interface IResourceActions
    {
        public void Add(Resource resource, int count);
        public void Remove(Resource resource, int count);
        public void Buy(Resource resource, int count, int price);
        public void Sell(Resource resource, int count, int price);
        public int GetCount(Resource resource);
        public bool Contains(Resource resource);
    }
}