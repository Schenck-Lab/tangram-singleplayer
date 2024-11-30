using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SetTurnType : MonoBehaviour
{
    public ActionBasedSnapTurnProvider snapTurn;
    public ActionBasedContinuousTurnProvider continuousTurn;

    public PuzzleManager pManage;

    public void SetTurnTypeFromIndex(int index)
    {
        if(index == 0)
        {
            snapTurn.enabled = false;
            continuousTurn.enabled = true;
        } else if(index == 1)
        {
            continuousTurn.enabled = false;
            snapTurn.enabled = true;
        }
    }

    public void SetProgressTextFromIndex(int index)
    {
        if (index == 0)
        {
            pManage.setHandText(index);
        }
        else if (index == 1)
        {
            pManage.setHandText(index);
        }
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
