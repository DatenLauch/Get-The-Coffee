using UnityEngine;
using UnityEngine.SceneManagement;

namespace StartScreen
{
    public class StartMenu : MonoBehaviour
    {
        public void OnPlayButton()
        {
            SceneManager.LoadScene(1);
        }

        public void OnQuitButton()
        {
            // source: https://stackoverflow.com/questions/70437401/cannot-finish-the-game-in-unity-using-application-quit
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    }
}