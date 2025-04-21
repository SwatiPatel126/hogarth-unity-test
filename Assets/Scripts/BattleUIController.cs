using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace CombatSystem
{
    public class BattleUIController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _battleOverMessage;
        [SerializeField]
        private GameObject _battleOverPopup;
        void Start()
        {
            _battleOverPopup.SetActive(false);
        }
        //Display battle over message with winner name
        public void ShowBattleOverPopup(string messageToDisplay)
        {
            _battleOverMessage.text = messageToDisplay;
            _battleOverPopup.SetActive(true);
        }

        public void OnRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
