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
            Coroutine newCoroutine = StartCoroutine(enumerator);
            return newCoroutine;
        }

        public void Stop(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}