using UnityEngine;
using UnityEngine.UI;
using Utils.EventSystem;
using Utils.Services;

namespace ExperienceSystem.UI
{
    public class PlayerLevelInfoPanel : MonoBehaviour
    {
        [SerializeField] private Image ExperienceLine;
        [SerializeField] private Text ExperienceText;
        [SerializeField] private Text LevelText;
        private void Start()
        {
            Events.Subscribe<PlayerGotNewLevelEvent>(UpdateLevel);
            Events.Subscribe<PlayerGotExperienceEvent>(UpdateExperience);
            InitPanel();
        }
        
        private void UpdateLevel(PlayerGotNewLevelEvent eventData)
        {
            UpdateLevel(eventData.NewLevel);
            UpdateExperience(eventData.CurrentExperience, eventData.ExpToNextLevel);
        }

        private void UpdateLevel(int level)
        {
            LevelText.text = level.ToString();
        }
        
        private void UpdateExperience(PlayerGotExperienceEvent eventData)
        {
            UpdateExperience(eventData.CurrentExperience, eventData.ExpToNextLevel);
        }

        private void UpdateExperience(int currentExp, int expToNextLevel)
        {
            ExperienceLine.fillAmount = currentExp * 1f / expToNextLevel;
            ExperienceText.text = $"{currentExp.ToString()}/{expToNextLevel.ToString()}";
        }

        private void InitPanel()
        {
            IPlayerExperience playerExperience = Services.GetService<IPlayerExperience>();
            UpdateLevel(playerExperience.Level);
            UpdateExperience(playerExperience.Experience, playerExperience.ExperienceToNextLevel);
        }
    }
}