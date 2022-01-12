namespace QuestSystem
{
    public class Quest : IQuest
    {
        public int QuestID { get; }
        public int ExperienceCount { get; }
        
        public Quest(int questID, int experienceCount)
        {
            QuestID = questID;
            ExperienceCount = experienceCount;
        }
    }
}