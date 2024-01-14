using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenus : MonoBehaviour
{
   
    public void Retry()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void MainMenu()
   {
       SceneManager.LoadScene(0);
   }

   public void Quit()
   {
       Application.Quit();
   }

   public void NextLevel()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   

}
