using System;
using Systems.ResourcesSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Systems.InventorySystem
{
    public class PlayerResourceInventoryItemView : MonoBehaviour
    {
        [SerializeField] private TMP_Text NameTextBox;
        [SerializeField] private TMP_Text CountTextBox;
        [SerializeField] private Image IconImage;
        [SerializeField] public Button SellButton;

        private Resource _resource;
        private int _count;

        public void SetItem(Resource resource, int count)
        {
            this._resource = resource;
            this._count = count;
            InitResourceInventoryItemView();
        }

        private void Start()
        {
            if (SellButton != null)
                SellButton.onClick.AddListener(() => SellItem(1)); // TODO Add slider to choose count
        }

        public void InitResourceInventoryItemView()
        {
            if (IconImage != null)
                if (_resource.Icon != null)
                    IconImage.sprite = _resource.Icon;
            
            if (NameTextBox != null)
                NameTextBox.text = _resource.Name;

            if (CountTextBox != null)
                CountTextBox.text = _count.ToString();
        }

        private void OnDestroy()
        {
            if (SellButton != null)
                SellButton.onClick.RemoveListener(() => SellItem(1));
        }

        private void SellItem(int count)
        {
            ResourceManager.Sell(_resource, count, _resource.baseSellPrice);
        }
    }
}