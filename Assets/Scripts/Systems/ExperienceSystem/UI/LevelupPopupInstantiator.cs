using UnityEngine;

namespace ExperienceSystem.UI
{
    public class LevelupPopupInstantiator : MonoBehaviour
    {
        [SerializeField] private LevelupPopup LevelupPopupPrefab;
        
        private void Start()
        {
            Utils.EventSystem.Events.Subscribe<PlayerGotNewLevelEvent>(Show);
        }

        private void Show(PlayerGotNewLevelEvent eventData)
        {
            GameObject popup = Instantiate(LevelupPopupPrefab.gameObject, this.transform);
            popup.GetComponent<LevelupPopup>().SetLevel(eventData.NewLevel);
        }
    }
}