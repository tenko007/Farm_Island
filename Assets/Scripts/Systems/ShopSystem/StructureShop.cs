using System;
using System.Collections.Generic;
using Systems.InventorySystem;
using UnityEditor;
using UnityEngine;
using Utils.Services;

namespace Systems.ResourcesSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Shop/StructureShop")]
    public class StructureShop : StandartShop<StructureShopItem>
    {
    }
}