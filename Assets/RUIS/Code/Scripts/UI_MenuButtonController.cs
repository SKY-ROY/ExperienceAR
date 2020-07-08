using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RUIS.UI
{
    public class UI_MenuButtonController : MonoBehaviour
    {
        public void GoToMenu()
        {
            SceneManager.LoadScene("UI_MENU");
        }
        public void SceneSwitch(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}