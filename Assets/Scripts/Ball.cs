using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    public static float initialForce = 600f;
    private bool ballStarted;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //DEBUGGING

    }

    private void OnCollisionEnter(Collision collision)
    {
        Brick brick = collision.gameObject.GetComponent<Brick>();
        if (brick != null)
        {
            brick.TakeDamage();
        }
    }

    public void StartBall()
    {
        if (!ballStarted)
        {
            rb.isKinematic = false;
            if (rb.transform.position.x < Camera.main.transform.position.x)
            {
                rb.AddForce(new Vector3(initialForce,initialForce,0));

            }
            else
            {
                rb.AddForce(new Vector3(-(initialForce),initialForce,0));

            }
            ballStarted = true;
            //PARENT BACK TO THE WORLD
            transform.SetParent(transform.parent.parent);
        }
    }
    public bool BallStarted()
    {
        return ballStarted;
    }
}
