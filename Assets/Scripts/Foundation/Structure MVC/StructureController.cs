using System;

namespace Foundation.MVC
{
    public abstract class StructureController : BaseContoller, IDisposable
    {
        public abstract void Dispose();
    }
}