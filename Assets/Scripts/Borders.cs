using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody balRb = collision.gameObject.GetComponent<Rigidbody>();
            float vel = Ball.initialForce / 2;
            Vector3 hitPoint = collision.contacts[0].point;
            float difference = transform.position.y - hitPoint.y;

            if (hitPoint.y < transform.position.y)
            {
                balRb.AddForce(new Vector3( vel,-(Mathf.Abs(difference * 5)), 0));
            }
            else
            {
                balRb.AddForce(new Vector3( vel,Mathf.Abs(difference * 5), 0));
            }
        }
    }
}
