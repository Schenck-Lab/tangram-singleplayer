using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PieceSnapScript : MonoBehaviour
{
    //Get GameObject for the Slot, Piece, and Alternative Slot if applicable
    public GameObject slot;
    public GameObject piece;
    public GameObject altSlot;

    //Floats for both angle and piece distances between slot and piece
    private float angleRotation;
    private float pieceDistance;

    void Update()
    {
        angleRotation = Mathf.Abs(Quaternion.Angle(piece.transform.rotation, slot.transform.rotation)); //Equation for angle difference between slot and piece
        pieceDistance = Vector3.Distance(piece.transform.position, slot.transform.position); //Equation for distance between slot and piece
        
        //Force piece velocities to zero
        piece.GetComponent<Rigidbody>().velocity = Vector3.zero;
        piece.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
    }

    //Method to check when an object is colliding with the slot
    private void OnTriggerStay(Collider other)
    {
        GameObject trigger = other.gameObject;

        //If the tag of the object colliding with the slot is the same as the slot
        if(trigger.tag == slot.tag){

            //If the piece angle difference and piece difference are within range of the slot
            if (angleRotation < 2.5 && pieceDistance < 0.02){

                //Disable the Collider, set velocity to zero, and disable the grabability of the piece
                trigger.GetComponent<XRGrabInteractable>().enabled = false;
                trigger.GetComponent<MeshCollider>().enabled = false;
                trigger.GetComponent<Rigidbody>().velocity = Vector3.zero;
                trigger.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                //Set Piece transform and rotation to the slot transform and push piece up slightly forward
                trigger.transform.SetPositionAndRotation(slot.transform.position - new Vector3(0,0,0.01f), slot.transform.rotation);

                //Update piece count after snapping
                PuzzleChecker.pieceCount++;

                //Get rid of slot object
                Destroy(slot);

                //If there is an alternate slot delete the alternate slot
                if(altSlot != null)
                {
                    Destroy(altSlot);
                }
            }
        }
    }
}
