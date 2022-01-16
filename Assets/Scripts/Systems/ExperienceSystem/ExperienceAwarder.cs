using QuestSystem;

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
            Utils.EventSystem.Events.Subscribe<QuestCompletedEvent>(AddExperience);
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