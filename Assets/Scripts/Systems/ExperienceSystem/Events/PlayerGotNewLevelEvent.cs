using System;

namespace ExperienceSystem.Events
{
    public class PlayerGotNewLevelEvent : EventArgs
    {
        public int NewLevel { get; } 
        public int CurrentExperience { get; }
        public int ExpToNextLevel { get; }

        public PlayerGotNewLevelEvent(int newLevel, int currentExp, int expToNextLevel)
        {
            this.NewLevel = newLevel;
            this.CurrentExperience = currentExp;
            this.ExpToNextLevel = expToNextLevel;
        }
    }
}