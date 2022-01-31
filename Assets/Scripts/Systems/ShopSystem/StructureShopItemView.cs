using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Systems.ResourcesSystem
{
    public class StructureShopItemView : MonoBehaviour
    {
        [SerializeField] private TMP_Text PriceTextBox;
        [SerializeField] private TMP_Text NameTextBox;
        [SerializeField] private Image IconImage;
        [SerializeField] private Button BuyButton;

        public StructureShopItem Item { get; private set; }
        public void SetItem(StructureShopItem item)
        {
            this.Item = item;
            InitShopItemView();
        }
        public void InitShopItemView()
        {
            if (IconImage != null)
                IconImage.sprite = Item.Icon;
            
            if (NameTextBox != null)
                NameTextBox.text = Item.Name;
            
            if (PriceTextBox != null)
                PriceTextBox.text = Item.Price.ToString();
            
            if (BuyButton != null)
                BuyButton.onClick.AddListener(() => Item.Buy(1));
        }
    }
}