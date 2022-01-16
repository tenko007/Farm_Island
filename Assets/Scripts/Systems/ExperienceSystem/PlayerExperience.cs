using ExperienceSystem.Events;

namespace ExperienceSystem
{
    public class PlayerExperience : IPlayerExperience
    {
        public int Level { get; private set; }

        public int Experience { get; private set; }
        public int ExperienceToNextLevel { get; private set; }
        public int MaxLevel { get; private set; }
        private ExperienceForLevels ExperienceForLevels { get; }

        public PlayerExperience(int level, int experience, ExperienceForLevels experienceForLevels)
        {
            this.Level = level;
            this.Experience = experience;
            this.ExperienceForLevels = experienceForLevels;
            this.MaxLevel = ExperienceForLevels.List.Count;
            ExperienceToNextLevel = ExperienceForLevels.List[Level - 1];
        }
        
        public void AddExperience(int count)
        {
            Experience += count;
            Utils.EventSystem.Events.Invoke(new PlayerGotExperienceEvent(count, Experience, ExperienceToNextLevel));
            CheckForLevelUp();
        }
        
        public void AddLevel()
        {
            if (Level == MaxLevel) 
                return;

            Level++;
            ExperienceToNextLevel = ExperienceForLevels.List[Level - 1];
            Utils.EventSystem.Events.Invoke(new PlayerGotNewLevelEvent(Level, Experience, ExperienceToNextLevel));
        }
        
        private void CheckForLevelUp()
        {
            if (Level == MaxLevel)
                return;
            
            if (Experience >= ExperienceToNextLevel)
            {
                Experience -= ExperienceToNextLevel;
                AddLevel();
                CheckForLevelUp();
            }
        }
    }
}