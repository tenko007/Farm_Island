using System;
using Foundation.MVC;
using Systems.BuildingSystem;
using Systems.ResourcesSystem;
using UnityEngine;
using UnityEngine.UI;
using Utils.EventSystem;
using Utils.Services;

namespace Systems.InventorySystem
{
    public class PlayerResourceInventoryView : MonoBehaviour
    {
        private IPlayerResourceInventory inventory;
        [SerializeField] private GameObject ItemsContainer;
        [SerializeField] private GameObject ItemPrefab;

        private Action<object> updateHandler;
        private void Start()
        {
            updateHandler = _ => InitInventoryView();
            inventory = Services.GetService<IPlayerResourceInventory>();
            InitInventoryView();
            Subscribe();
        }
        
        private void OnDestroy() => UnSubscribe();

        private void InitInventoryView()
        {
            Clear();
            
            foreach (var item in inventory.Items)
            {
                GameObject.Instantiate(ItemPrefab, ItemsContainer.transform)
                    .GetComponent<PlayerResourceInventoryItemView>()
                    .SetItem(item.Key, item.Value);
            }
        }

        private void Clear()
        {
            foreach (var item in ItemsContainer.GetComponentsInChildren<PlayerResourceInventoryItemView>())
                Destroy(item.gameObject);
        }

        private void Subscribe()
        {
            Events.Subscribe<ResourceAddedEvent>(updateHandler);
            Events.Subscribe<ResourceRemovedEvent>(updateHandler);
        }
        
        private void UnSubscribe()
        {
            Events.Unsubscribe<ResourceAddedEvent>(updateHandler);
            Events.Unsubscribe<ResourceRemovedEvent>(updateHandler);
        }
    }
}