using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Specifications : MonoBehaviour
{
    public int healthPoints = 3;
    public bool startGame = false;
    public bool loseGame = false;
    public bool finGame = false;

    private void Update()
    {
        if (healthPoints == 0)
        {
            startGame = false;
            loseGame = true;
        }
    }
}
