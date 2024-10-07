using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Specifications>().healthPoints = 0;
    }
}
