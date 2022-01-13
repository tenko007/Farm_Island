using UnityEngine;
using UnityEngine.UI;

namespace ExperienceSystem.UI
{
    public class LevelupPopup : MonoBehaviour
    {
        [SerializeField] private GameObject RewardsList;
        [SerializeField] private Text LevelText;
        private int level;
        
        private void Start()
        {
            UpdateVisualData();
        }
        private void UpdateVisualData()
        {
            LevelText.text = level.ToString();
        }
        public void SetLevel(int level)
        {
            this.level = level;
        }
    }
}