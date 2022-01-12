using System;

namespace ExperienceSystem.Events
{
    public class PlayerExperienceInstantiatedEvent : EventArgs
    {
        public int CurrentLevel { get; } 
        public int CurrentExperience { get; }
        public int ExpToNextLevel { get; }

        public PlayerExperienceInstantiatedEvent(int currentLevel, int currentExperience, int expToNextLevel)
        {
            CurrentLevel = currentLevel;
            CurrentExperience = currentExperience;
            ExpToNextLevel = expToNextLevel;
        }
    }
}