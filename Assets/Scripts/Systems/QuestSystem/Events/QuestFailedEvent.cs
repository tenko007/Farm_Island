using System;

namespace QuestSystem.Events
{
    public class QuestFailedEvent : EventArgs
    {
        private Quest questData;
        public QuestFailedEvent(Quest questData)
        {
            this.questData = questData;
        }
    }
}