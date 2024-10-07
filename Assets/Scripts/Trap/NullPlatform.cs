using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class NullPlatform : MonoBehaviour
{
    public float timer;
    public int stat;
    public GameObject platform;

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            stat += 1;
            timer = 0;
        }

        switch (stat)
        {
            case 0:
                platform.SetActive(true);
                break;

            case 1:
                platform.SetActive(false);
                break;
            case 2:
                stat = 0;
            break;
        }
    }
}
