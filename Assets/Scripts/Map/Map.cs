using UnityEngine;

namespace Systems.BuildingSystem
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private GameObject groundGameObject;
        [SerializeField] private LayerMask groundLayer;
        public GameObject GroundGameObject => groundGameObject;
        public LayerMask GroundLayer => groundLayer;
    }
}