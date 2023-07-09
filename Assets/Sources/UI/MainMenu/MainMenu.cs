using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        public void OnButtonPlayClick()
        {
            SceneManager.LoadScene("Scenes/LevelGreyBox/Level_01");
        }

        public void OnButtonCreditClick()
        {
            SceneManager.LoadScene("Scenes/Credit");
        }
        
        public void OnButtonQuitClick()
        {
#if UNITY_STANDALONE
            Application.Quit();
#endif
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}