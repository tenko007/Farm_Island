using System;
using UnityEngine;

namespace Foundation.MVC
{
    [Serializable]
    public abstract class BaseModel : ScriptableObject
    {
        public abstract GameObject Prefab { get; }
    }

    public abstract class Structure : BaseModel
    {
        public string Name { get; }
        public string Description { get; }
        public Sprite Icon { get; }
    }
}