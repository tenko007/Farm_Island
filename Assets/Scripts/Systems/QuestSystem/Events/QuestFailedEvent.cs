using System;

namespace QuestSystem
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