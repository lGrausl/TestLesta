using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    public GameObject trigger;
    public GameObject platform;
    public bool itStart = true;

    public float timeLeft;
    public bool timer = false;

    private Renderer platformColor;
    private GameObject player;

    public void Awake()
    {
        Collider collider = trigger.GetComponent<Collider>();
        platformColor = platform.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (itStart)
        {
            timer = true;
            platformColor.material.color = Color.green;
        }
        else
        {
            timer = false;
            platformColor.material.color = Color.yellow;
            other.GetComponent<Specifications>().finGame = true;
            other.GetComponent<Specifications>().startGame = false;  
        }
    }


    private void FixedUpdate()
    {
        if (timer == true)
        {
            timeLeft += Time.deltaTime;
        }

    }

}
