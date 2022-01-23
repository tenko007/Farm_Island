using System;
using UnityEngine;

namespace Foundation.MVC
{
    [Serializable]
    public abstract class BaseModel : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        public GameObject Prefab => prefab;
    }
}