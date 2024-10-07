using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerDamageTrap : Specifications
{
    public GameObject trigger;
    public GameObject platform;
    private GameObject player;

    public float timerActivated = 5;
    private float timeLeft;
    private bool timer = false;

    private Renderer platformColor;

    public void Awake()
    {
        Collider collider = trigger.GetComponent<Collider>();
        platformColor = platform.GetComponent<Renderer>();
        timeLeft = timerActivated;
    }

    private void OnTriggerEnter(Collider other)
    {
        timer = true;
        player = other.gameObject;
    }


    private void FixedUpdate()
    {
        if (timer == true) 
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                platformColor.material.color = Color.red;
                timer = false;
                player.GetComponent<Specifications>().healthPoints -= 1;
            }
           
        }
    }


    private void OnTriggerExit(Collider other)
    {
        platformColor.material.color = Color.white;
        timer = false;
        timeLeft = timerActivated;
        player = null;
    }


}
