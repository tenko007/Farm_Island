using QuestSystem;
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
            Events.Subscribe<QuestCompletedEvent>(data =>
                AddExperience(data.Quest.ExperienceCount));
            // more other ...
        }
        private void AddExperience(int count) =>
            playerExperience.AddExperience(count);
    }
}