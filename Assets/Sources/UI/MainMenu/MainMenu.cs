using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        public void OnStartButton()
        {
            Debug.Log("START");
            SceneManager.LoadScene(1);
        }
        
        public void OnQuitButton()
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