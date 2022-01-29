using System;
using System.Dynamic;
using UnityEngine;

namespace Foundation.MVC
{
    public abstract class BaseView : MonoBehaviour 
    {
        [SerializeField] private BaseModel model;
        public BaseModel Model => model;
        protected BaseContoller controller;
        private bool inited;

        private void Awake()
        {
            if (!inited) 
                Init(model);
        }

        public virtual void Init(BaseModel newModel)
        {
            model = newModel;
            controller.Setup(Instantiate(newModel));
            inited = true;
        }
    }
}