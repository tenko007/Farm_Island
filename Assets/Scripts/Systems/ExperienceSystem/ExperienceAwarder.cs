using QuestSystem.Events;
using Utils.EventSystem;

namespace ExperienceSystem
{
    public class ExperienceAwarder : IExperienceAwarder
    {
        private IPlayerExperience playerExperience;

        public ExperienceAwarder(IPlayerExperience playerExperience)
        {
            this.playerExperience = playerExperience;
            SubscribeEvents();
        }

        public void SubscribeEvents()
        {
            EventSystem.Subscribe<QuestCompletedEvent>(AddExperience);
            // more other ...
        }

        private void AddExperience(QuestCompletedEvent questData)
        {
            AddExperience(questData.Quest.ExperienceCount);
        }
        
        private void AddExperience(int count)
        {
            playerExperience.AddExperience(count);
        }
    }
}