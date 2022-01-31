using System;
using System.Collections.Generic;
using Systems.BuildingSystem;
using UnityEngine;
using Utils.EventSystem;
using Utils.Services;

namespace Systems.ResourcesSystem
{
    public class StructureShopView : MonoBehaviour
    {
        [SerializeField] private StructureShop shop;
        [SerializeField] private GameObject ItemsContainer;
        [SerializeField] private GameObject ItemPrefab;

        private void Start()
        {
            InitShopView();
            Services.GetService<IBuildingSystem>().OnBuildingStart += Close;
        }

        private void OnDestroy()
        {
            Close(null);
        }

        private void InitShopView()
        {
            foreach (var item in shop.Items)
            {
                Instantiate(ItemPrefab, ItemsContainer.transform)
                    .GetComponent<StructureShopItemView>().SetItem(item);
            }
        }

        private void Close(object anything)
        {
            Services.GetService<IBuildingSystem>().OnBuildingStart -= Close;
            Destroy(this.gameObject);
        }
    }
}