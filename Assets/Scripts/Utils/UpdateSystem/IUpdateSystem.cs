using System;
using UnityEngine.PlayerLoop;

namespace Utils.UpdateSystem
{
    public interface IUpdateSystem
    {
        public void Add(IUpdatable updatable);
        public void Remove(IUpdatable updatable);
    }
}