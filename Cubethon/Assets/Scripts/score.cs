using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    public static score instance;
    private void Awake()
    {
        instance = this;
        InvokeRepeating("SetScore", 1f, .5f);
    }
    private void SetScore()
    {
        scoreText.text = player.position.z.ToString("0");
    }
}
