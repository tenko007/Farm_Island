using System;
using System.Dynamic;
using UnityEngine;

namespace Foundation.MVC
{
    public abstract class BaseView<TM,TC> : MonoBehaviour 
        where TM : BaseModel 
        where TC : BaseContoller<TM>, new()
    {
        [SerializeField] private TM model;
        protected TC controller;
        private bool inited; 
        
        private void Awake()
        {
            if (!inited) 
                Init(model);
        }

        public virtual void Init(TM newModel)
        {
            controller = new TC();
            controller.Setup(Instantiate(newModel));
            inited = true;
        }
    }
}