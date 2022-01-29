using System;
using UnityEngine;

namespace Systems.BuildingSystem
{
    public class BuildingMoved : EventArgs
    {
        private GameObject _gameObject;
        private Vector3 _prevPosition;
        private Vector3 _newPosition;

        public BuildingMoved(GameObject gameObject, Vector3 prevPosition, Vector3 newPosition)
        {
            this._gameObject = gameObject;
            this._prevPosition = prevPosition;
            this._newPosition = newPosition;
        }
    }
}