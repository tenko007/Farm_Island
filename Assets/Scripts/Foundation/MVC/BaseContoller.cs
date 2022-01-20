namespace Foundation.MVC
{
    public abstract class BaseContoller<TM> where TM : BaseModel
    {
        protected TM model;
        public virtual void Setup(TM model)
        {
            this.model = model;
        }
    }
}