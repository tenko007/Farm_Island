using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.BuildingSystem
{
    public class CoroutinesUpdater : MonoBehaviour, ICoroutinesUpdater
    {
        private Dictionary<IEnumerator, Coroutine> _coroutines;

        private void Awake()
        {
            _coroutines = new Dictionary<IEnumerator, Coroutine>();
        }

        public void StartA(IEnumerator enumerator)
        {
            Coroutine newCoroutine = StartCoroutine(enumerator);
            _coroutines.Add(enumerator, newCoroutine);
        }

        public void Stop(IEnumerator enumerator)
        {
            if (_coroutines.TryGetValue(enumerator, out var coroutine))
            {
                StopCoroutine(coroutine);
                _coroutines.Remove(enumerator);
            }
        }
    }
}