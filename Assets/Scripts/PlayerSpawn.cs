using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject spawn;
    public InputActionProperty resetButton;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        player.transform.SetPositionAndRotation(spawn.transform.position, spawn.transform.rotation);

    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (resetButton.action.WasPressedThisFrame())
        {
            resetPosition();
        }
    }

    void resetPosition()
    {
        player.transform.SetPositionAndRotation(spawn.transform.position, spawn.transform.rotation);
    }
}
