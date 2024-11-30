using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenuManager : MonoBehaviour
{
    public GameObject menu;
    public PuzzleManager manager;

    public void gameStart()
    {
        manager.startGame();
        menu.SetActive(false);
    }   
}
