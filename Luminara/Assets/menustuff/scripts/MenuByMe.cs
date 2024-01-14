using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuByMe : MonoBehaviour
{
    public GameObject levelMenu;
    public GameObject settingsMenu;
    public GameObject mainMenu;
    
    

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelMenu()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void SettingsMenu()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);
        settingsMenu.SetActive(true);

    }

    public void BackToMenu()
    {
        levelMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
