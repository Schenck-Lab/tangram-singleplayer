using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Pause Menu Manager Script to manage position and orientation

public class GameMenuManager : MonoBehaviour
{
    public Transform head; //Get Transform component of VR Head object
    public float spawnDist = 2; //Set Distance between VR Head and Menu
    public GameObject menu; //Get GameObject from the scene
    public InputActionProperty showButton; //Get Input button for Menu


    void Update()
    {
        //If the menu button is pressed
        if (showButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf); //Toggle Menu based on if it is active or not

            menu.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized * spawnDist; //Set Menu position equation based on head position
        }

        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z)); //Menu follows player's head
        menu.transform.forward *= -1; //Flips Menu to the correct orientation
    }
}
