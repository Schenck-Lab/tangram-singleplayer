using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Menu Manager for the Main Menu

public class MainMenuManager : MonoBehaviour
{
    //Quit Application method
    public void quitGame()
    {
        Application.Quit();
    }

    //Start Puzzle Scene method
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

}
