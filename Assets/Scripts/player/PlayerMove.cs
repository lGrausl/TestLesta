using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerMove : MonoBehaviour
{
    public float speed = 1000f;
    public float jumpForce = 300f;
    public float rotSpeed = 30f;

    public int heatPoint = 100;

    private bool isGrounded;
    private Rigidbody rb;

    public Transform target;
    private Vector3 vectorMovement;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (this.GetComponent<Specifications>().startGame)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");


            if (moveHorizontal != 0 || moveVertical != 0)
            {
                vectorMovement.x = moveHorizontal * speed;
                vectorMovement.z = moveVertical * speed;
                vectorMovement = Vector3.ClampMagnitude(vectorMovement, speed);

                Quaternion tmp = target.rotation;
                target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
                vectorMovement = target.TransformDirection(vectorMovement);
                target.rotation = tmp;

                Quaternion direction = Quaternion.LookRotation(vectorMovement);
                transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);

            }
            vectorMovement *= Time.deltaTime;
            rb.AddForce(vectorMovement);

            if (Input.GetAxis("Jump") > 0)
            {
                if (isGrounded)
                {
                    rb.AddForce(Vector3.up * jumpForce);


                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = value;
        }
    }
}


