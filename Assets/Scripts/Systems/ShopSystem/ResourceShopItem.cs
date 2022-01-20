using System;
using Utils.EventSystem;

namespace Systems.ResourcesSystem
{
    [Serializable]
    public class ResourceShopItem : IShopItem
    {
        public Resource Resource;
        public int Price;
        public int MinLevelToBuy;

        public void Buy(int count)
        {
            Events.Invoke(new ResourceBoughtEvent(new ResourceObject(Resource,count),Price*count));
        }

        public bool CanBeBought()
        {
            // TODO
            return true;
        }
    }
}