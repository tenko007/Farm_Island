namespace Foundation.MVC
{
    public interface IBaseView
    {
        BaseModel Model { get; }

        public void Init(BaseModel newModel);
    }
}