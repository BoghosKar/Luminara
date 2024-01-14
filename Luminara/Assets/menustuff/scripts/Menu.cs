using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Animator anim;

    public GameObject MainScreen;
    public GameObject LeveLSelectScreen;
    public GameObject SettingsScreen;

    public bool islevelselect;
    public bool issettings;

    public void LevelSelect(){
        if(islevelselect){
            islevelselect = false;
            anim.SetBool("levelselect", false);
            MainScreen.SetActive(true);
            LeveLSelectScreen.SetActive(false);
        }else{
            islevelselect = true;
            anim.SetBool("levelselect", true);
            MainScreen.SetActive(false);
            LeveLSelectScreen.SetActive(true);
        }
    }    
    public void Settings(){
        if(issettings){
            issettings = false;
            anim.SetBool("settings", false);
            MainScreen.SetActive(true);
            SettingsScreen.SetActive(false);
        }else{
            issettings = true;
            anim.SetBool("settings", true);
            MainScreen.SetActive(false);
            SettingsScreen.SetActive(true);
        }
    }

    public void QuitGame(){
        Application.Quit();
    }
}
