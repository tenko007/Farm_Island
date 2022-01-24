using Systems.BuildingSystem;
using UnityEngine;
using UnityEngine.UI;
using Utils.Services;

namespace UI
{
    public class UIBuildingActions : MonoBehaviour
    {
        [SerializeField] private Button ButtonOk;
        [SerializeField] private Button ButtonCancel;

        private void Start()
        {
            ButtonOk.onClick.AddListener(() => EndBuilding());
            ButtonCancel.onClick.AddListener(() => CancelBuilding());
        }

        public void EndBuilding()
        {
            Services.GetService<IBuildingSystem>().EndBuild();
            Destroy(this.gameObject);
        }

        public void CancelBuilding()
        {
            Services.GetService<IBuildingSystem>().CancelBuild();
            Destroy(this.gameObject);
        }
        
    }
}