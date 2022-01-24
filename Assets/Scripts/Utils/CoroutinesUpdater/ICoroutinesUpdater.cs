using System.Collections;
using UnityEngine;

namespace Systems.BuildingSystem
{
    public interface ICoroutinesUpdater
    {
        public void StartA(IEnumerator enumerator);
        public void Stop(IEnumerator enumerator);
    }
}