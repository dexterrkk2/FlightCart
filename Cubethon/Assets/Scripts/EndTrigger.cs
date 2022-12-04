using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public string nextLevel;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.completeLevelUI.SetActive(true);
        Invoke("ChangeScene", 1f);
    }
    public void ChangeScene()
    {
            Networkmanager.instance.ChangeScene(nextLevel);
    }
}
