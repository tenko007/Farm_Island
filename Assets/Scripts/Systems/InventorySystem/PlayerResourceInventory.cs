using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Systems.ResourcesSystem;
using UnityEngine;
using Utils.EventSystem;

namespace Systems.InventorySystem
{
    public class PlayerResourceInventory : IPlayerResourceInventory
    {
        public Dictionary<Resource, int> Items { get; }

        public PlayerResourceInventory()
        {
            this.Items = new Dictionary<Resource, int>();
        }
        
        public PlayerResourceInventory(Dictionary<Resource, int> items)
        {
            this.Items = items;
        }

        public bool Add(Resource item, int count)
        {
            Debug.Log($"{count.ToString()} pcs. of {item.Name}s added to PlayerResourceInventory!"); // TODO Remove

            if (Items.ContainsKey(item))
                Items[item] += count;
            else
                Items.Add(item, count);
            
            Events.Invoke(new ResourceAddedEvent(new ResourceObject(item,count)));
            return true;
        }

        public bool Remove(Resource item, int count)
        {
            if (Items.ContainsKey(item))
            {
                Items[item] -= count;
                return true;
            }
            
            Events.Invoke(new ResourceRemovedEvent(new ResourceObject(item,count)));
            return false;
        }

        public bool Contains(Resource item)
        {
            return Items.ContainsKey(item);
        }

        public bool Contains(Resource item, int count)
        {
            return Items.ContainsKey(item) && Items[item] >= count;
        }
    }
}