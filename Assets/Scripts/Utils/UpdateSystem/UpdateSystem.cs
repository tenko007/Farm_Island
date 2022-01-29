using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils.UpdateSystem
{
    public class UpdateSystem: MonoBehaviour, IUpdateSystem
    {
        private List<IUpdatable> UpdateList = new List<IUpdatable>();
        private List<IUpdatable> RemoveList = new List<IUpdatable>();

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private void Update()
        {
            foreach (var element in RemoveList)
                UpdateList.Remove(element);
            
            foreach (var updatable in UpdateList)
                updatable.Update();
            
            RemoveList.Clear();
        }

        public void Add(IUpdatable updatable)
        {
            if (!UpdateList.Contains(updatable))
                UpdateList.Add(updatable);
        }

        public void Remove(IUpdatable updatable)
        {
            RemoveList.Add(updatable);
        }
    }
}