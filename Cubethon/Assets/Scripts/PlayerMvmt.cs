using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerMvmt : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float upwardForce = 50f;
    public float maxY;
    public float maxX;
    [Header("Photon")]
    public int id;
    public Player photonPlayer;
    public static PlayerMvmt instance;
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if ( Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("w"))
        {
            rb.AddForce(0, upwardForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, -upwardForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -maxY)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (rb.position.y > maxY)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (rb.position.x < -maxX)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (rb.position.x > maxX)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
