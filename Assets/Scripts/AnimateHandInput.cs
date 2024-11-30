using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//Animation Script for Hands
public class AnimateHandInput : MonoBehaviour
{

    public InputActionProperty pinchAnimAction; //Pinch Animation Input
    public InputActionProperty gripAnimAction; //Grip Animation Input
    public Animator handAnimator;


    void Update()
    {
        float triggerValue = pinchAnimAction.action.ReadValue<float>(); //Read Input value for Trigger Button
        float gripValue = gripAnimAction.action.ReadValue<float>(); //Read Input Value for Grip Button

        handAnimator.SetFloat("Grip", gripValue); //Animate Grip according to Grip Button Value
        handAnimator.SetFloat("Trigger", triggerValue); //Animate Trigger according to Trigger Button Value
    }
}
