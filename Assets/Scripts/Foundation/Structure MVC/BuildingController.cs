using System;

namespace Foundation.MVC
{
    public abstract class BuildingController : BaseContoller, IDisposable
    {
        public abstract void Dispose();
    }
}