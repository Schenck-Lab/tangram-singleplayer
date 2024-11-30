using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOverlay : MonoBehaviour
{
    public float overlayTimeSeconds = 0;

    private GameObject overlay;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        overlay = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > overlayTimeSeconds)
        {
            overlay.SetActive(false);
        }
    }
}
