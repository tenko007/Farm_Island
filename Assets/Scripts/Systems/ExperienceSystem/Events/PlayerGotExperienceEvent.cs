using System;

namespace ExperienceSystem
{
    public class PlayerGotExperienceEvent : EventArgs
    {
        public int expCount { get; } 
        public int CurrentExperience { get; }
        public int ExpToNextLevel { get; }
        
        public PlayerGotExperienceEvent(int expCount, int currentExperience, int expToNextLevel)
        {
            this.expCount = expCount;
            this.CurrentExperience = currentExperience;
            this.ExpToNextLevel = expToNextLevel;
        }
    }
}