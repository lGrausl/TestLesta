using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraConsrolers : MonoBehaviour
{
    [SerializeField] private Transform target;
    public GameObject player;

    public float rotSpeed = 1.5f;


    private float rotY;
    private float rotX;
    private Vector3 offset;

    private void Start()
    {
        rotX = transform.position.x;
        rotY = transform.eulerAngles.y;
        offset = target.position - transform.position;
    }

    private void LateUpdate()
    {
        if (player.GetComponent<Specifications>().startGame)
        {


            rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;

            rotX += Input.GetAxis("Mouse Y") * rotSpeed * 3;

            Quaternion rotation = Quaternion.Euler(-rotX, rotY, 0);
            transform.position = target.position - (rotation * offset);
            transform.LookAt(target);

        }
    }
}