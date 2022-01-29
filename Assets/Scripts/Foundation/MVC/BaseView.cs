using System;
using System.Dynamic;
using UnityEngine;

namespace Foundation.MVC
{
    public abstract class BaseView<T> : MonoBehaviour, IBaseView
        where T : BaseContoller
    {
        [SerializeField] private BaseModel model;
        public BaseModel Model => model;
        protected T controller;
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