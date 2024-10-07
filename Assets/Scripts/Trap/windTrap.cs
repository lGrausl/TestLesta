using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windTrap : MonoBehaviour
{
    public GameObject trigger;
    public GameObject platform;
    public GameObject player;
    public float powerWind = 1f;
    public float timeLeft = 2f;
    bool vector = false;

    private bool windActivated = false;

    private Renderer platformColor;

    public void Awake()
    {
        Collider collider = trigger.GetComponent<Collider>();
        platformColor = platform.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
        windActivated = true;
    }


    private void FixedUpdate()
    {

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 2f;
            vector = !vector;
        }


        if (windActivated)
        {
            if(vector)
                player.GetComponent<Transform>().transform.Translate(Vector3.left * powerWind);
            else
                player.GetComponent<Transform>().transform.Translate(Vector3.right * powerWind);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        windActivated = false;
        player = null;
    }

}
