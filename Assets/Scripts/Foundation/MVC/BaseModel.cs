using System;
using UnityEngine;

namespace Foundation.MVC
{
    [Serializable]
    public abstract class BaseModel : ScriptableObject
    {
        public abstract GameObject Prefab { get; }
    }
}