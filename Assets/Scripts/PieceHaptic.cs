using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

//Script to manage haptic feedback for controller during piece snapping

public class PieceHaptic : MonoBehaviour
{
    float prevCount = 0; //Previous piece count for checking if piece count was updated

    bool active = true; //Boolean for if haptic feedback setting is active

    [SerializeField]
    XRBaseController controller; //Get the VR Hand Controller

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)//If the haptic feedback setting is active
        {
            if (PuzzleChecker.pieceCount > prevCount) //If the current piece count is greater than the previous recorded piece count
            {
                controller.SendHapticImpulse(1f, 0.2f); //Vibrate hand controller
                prevCount = PuzzleChecker.pieceCount; //Update previous piece count
            }
            else if (PuzzleChecker.pieceCount < prevCount) //If the current piece count becomes reset
            {
                prevCount = PuzzleChecker.pieceCount; //Set the prev counter to the current piece count
            }
        }
    }

    public void toggleActive() //Method to toggle the haptic feedback setting
    {
        if (active)
            active = false;
        else if (!active)
            active = true;
    }
}