using UnityEngine;
using UnityEngine.UI;
using Utils.EventSystem;

namespace ExperienceSystem.UI
{
    public class PlayerExperienceTextNotification : MonoBehaviour
    {
        [SerializeField] private Text experienceTextNotification;

        private void Start()
        {
            Events.Subscribe<PlayerGotExperienceEvent>(ShowTextNotification);
        }

        private void ShowTextNotification(PlayerGotExperienceEvent eventData)
        {
            GameObject newText = Instantiate(experienceTextNotification.gameObject, transform);
            newText.GetComponent<Text>().text = $"+ {eventData.expCount.ToString()} EXP";
            newText.SetActive(true);
            Destroy(newText, 2f);
        }
    }
}