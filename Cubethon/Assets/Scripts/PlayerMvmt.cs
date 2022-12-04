using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerMvmt : MonoBehaviourPunCallbacks
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
    [PunRPC]
    public void Initialize(Player player)
    {
        id = player.ActorNumber;
        photonPlayer = player;
        //photonPlayer = player;

        GameManager.instance.players[id - 1] = this;

        // if this isn't our local player, disable physics as that's
        // controlled by the user and synced to all other clients
        if (player.IsLocal)
        {
            instance = this;
        }
        else
        {
            //rig.isKinematic = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        rb.MoveRotation(CameraController.instance.transform.rotation);
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(0, -(Input.GetAxis("Mouse X")) * Time.deltaTime * forwardForce, 0);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(0, -(Input.GetAxis("Mouse X")) * Time.deltaTime * forwardForce, 0);
        }
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
            GameManager.instance.EndGame();
        }

        if (rb.position.y > maxY)
        {
            GameManager.instance.EndGame();
        }

        if (rb.position.x < -maxX)
        {
            GameManager.instance.EndGame();
        }

        if (rb.position.x > maxX)
        {
            GameManager.instance.EndGame();
        }
    }
}
