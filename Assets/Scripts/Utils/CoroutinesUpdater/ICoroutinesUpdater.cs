using System.Collections;
using UnityEngine;

namespace Systems.BuildingSystem
{
    public interface ICoroutinesUpdater
    {
        public Coroutine StartA(IEnumerator enumerator);
        public void Stop(Coroutine coroutine);
    }
}