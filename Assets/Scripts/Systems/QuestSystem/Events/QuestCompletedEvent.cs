using System;

namespace QuestSystem
{
    public class QuestCompletedEvent : EventArgs
    {
        public Quest Quest { get; }
        public QuestCompletedEvent(Quest quest)
        {
            this.Quest = quest;
        }
    }
}