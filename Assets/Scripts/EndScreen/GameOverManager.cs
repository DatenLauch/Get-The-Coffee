using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EndScreen
{
    public class GameOverManager : MonoBehaviour
    {
        [SerializeField] protected RawImage successImage;
        [SerializeField] protected RawImage failureImage;
        [SerializeField] protected TextMeshProUGUI gameInfoText;
        [SerializeField] protected GameObject blurPanel;
        
        [SerializeField] protected GameObject player;
        [SerializeField] protected GameObject keyboardMovement;

        private bool _gameCompleted = false;
        private float _timeLeft;
        private RawImage _endScreenImage;

        void ShowEndScreen()
        {
            blurPanel.SetActive(true);

            _endScreenImage = _gameCompleted ? successImage : failureImage;
            
            int minutes = Mathf.FloorToInt(_timeLeft / 60f);
            int seconds = Mathf.RoundToInt(_timeLeft % 60f);

            string minutesText = minutes.ToString("00");
            string secondsText = seconds.ToString("00");

            gameInfoText.text = $"{minutesText} : {secondsText}";

            _endScreenImage.gameObject.SetActive(true);
            if (_gameCompleted)
            {
                gameInfoText.gameObject.SetActive(true);
            }
        }

        public void EndGame(bool isCompleted, float timeRemaining)
        {
            _gameCompleted = isCompleted;
            _timeLeft = timeRemaining;
            
            DisablePlayerMovement();
            ShowEndScreen();
        }

        void DisablePlayerMovement()
        {
            KeyboardMovement keyboardMovementComponent = keyboardMovement.GetComponent<KeyboardMovement>();
            if (keyboardMovementComponent != null)
            {
                keyboardMovementComponent.DisableKeyboardMovement();
            }
            Movement arduinoMovementComponent = player.GetComponentInChildren<Movement>();
            if (arduinoMovementComponent != null)
            {
                arduinoMovementComponent.DisableArduinoMovement();
            }
        }
    }
}