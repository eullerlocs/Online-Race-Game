using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WinCondition : MonoBehaviour
{
    public AudioSource buttonClick,menuMusic;
    private void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.LoadLevel("Win");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        buttonClick.Play();
        PhotonNetwork.LoadLevel("Game");
    }
    public void Quit()
    {
        buttonClick.Play();
        Application.Quit();
    }
}
