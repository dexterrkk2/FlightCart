using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{

    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    [Header("Players")]
    public string playerPrefabLocation; // path in Resources folder to the Player prefab
    public Transform[] spawnPoints; // array of all available spawn points
    public PlayerMvmt[] players; // array of all the players
    public float respawnTime;
    private int playersInGame; // number of players in the game
    // instance
    public static GameManager instance;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Gameover");
            //Invoke("Restart", restartDelay);
        }
    }
    void SpawnPlayer()
    {
        // instantiate the player across the network
        GameObject playerObj = PhotonNetwork.Instantiate(playerPrefabLocation, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        // get the player script
        PlayerMvmt player = playerObj.GetComponent<PlayerMvmt>();
        //playerObj.GetComponent<PlayerMvmt>().photonView.RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }
    void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
}
