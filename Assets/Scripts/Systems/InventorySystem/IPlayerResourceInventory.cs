using System;
using System.Collections.Generic;
using Systems.ResourcesSystem;

namespace Systems.InventorySystem
{
    public interface IPlayerResourceInventory  : IInventory<Resource, int>
    {
        public Dictionary<Resource, int> Items { get; }
    }
}