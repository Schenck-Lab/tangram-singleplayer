using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PieceSnapParallelogram : MonoBehaviour
{
    public GameObject slot;
    public GameObject piece;
    public GameObject altSlot;

    private float angleRotation;
    private float pieceDistance;


    void Start()
    {

    }


    void Update()
    {
        angleRotation = Mathf.Abs(Quaternion.Angle(piece.transform.rotation, slot.transform.rotation)) % 180;
        pieceDistance = Vector3.Distance(piece.transform.position, slot.transform.position);
        piece.GetComponent<Rigidbody>().velocity = Vector3.zero;
        piece.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

    private void OnTriggerStay(Collider other)
    {
        GameObject trigger = other.gameObject;
        if (trigger.tag == slot.tag)
        {
            if ((angleRotation < 2 || angleRotation > 178) && pieceDistance < 0.05)
            {

                trigger.GetComponent<XRGrabInteractable>().enabled = false;
                trigger.GetComponent<MeshCollider>().enabled = false;
                trigger.GetComponent<Rigidbody>().velocity = Vector3.zero;
                trigger.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                trigger.transform.SetPositionAndRotation(slot.transform.position - new Vector3(0, 0, 0.01f), slot.transform.rotation);
                //trigger.transform.position = new Vector3(trigger.transform.position.x, trigger.transform.position.y, 0.015f);

                PuzzleChecker.pieceCount++;
                Destroy(slot);
                if (altSlot != null)
                {
                    Destroy(altSlot);
                }
            }
        }
    }
}
