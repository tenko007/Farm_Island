using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Systems.BuildingSystem
{
    public class CoroutinesUpdater : MonoBehaviour, ICoroutinesUpdater
    {
        public Coroutine StartA(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        }

        public void Stop(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}