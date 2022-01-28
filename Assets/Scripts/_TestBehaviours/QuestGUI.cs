using QuestSystem;
using UnityEngine;
using Utils.EventSystem;

namespace _TestBehaviors
{
    public class QuestGUI : MonoBehaviour
    {
#if UNITY_EDITOR
        private void OnGUI()
        {
            GUILayout.Space(200);
            
            if (GUILayout.Button("Complete Quest for 5 exp"))
                Events.Invoke(new QuestCompletedEvent(new Quest(1, 5)));
            if (GUILayout.Button("Complete Quest for 10 exp"))
                Events.Invoke(new QuestCompletedEvent(new Quest(1, 10)));
            if (GUILayout.Button("Complete Quest for 100 exp"))
                Events.Invoke(new QuestCompletedEvent(new Quest(1, 100)));
            if (GUILayout.Button("Complete Quest for 1000000 exp"))
                Events.Invoke(new QuestCompletedEvent(new Quest(1, 1000000)));
            
            //else if (GUILayout.Button("Fail Quest"))
            //    EventSystem.Invoke(new QuestFailedEvent(new Quest(1, 100)));
        }
#endif
    }
}