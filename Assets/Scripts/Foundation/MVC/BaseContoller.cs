namespace Foundation.MVC
{
    public abstract class BaseContoller//<TM> where TM : BaseModel
    {
        protected BaseModel model;
        public virtual void Setup(BaseModel model)
        {
            this.model = model;
        }
    }
}