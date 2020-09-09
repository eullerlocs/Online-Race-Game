using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MyLobby : MonoBehaviourPunCallbacks
{
    public string playerName;
    public GameObject joinPanel;
    public AudioSource buttonClick;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        buttonClick.Play();
        PhotonNetwork.LocalPlayer.NickName = playerName;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        joinPanel.SetActive(true);
    }

    public void JoinRoom()
    {
        buttonClick.Play();
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        string roomName = "Room";
        RoomOptions rOp = new RoomOptions();
        rOp.MaxPlayers = 20;
        PhotonNetwork.CreateRoom(roomName, rOp);

    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
    }

    public void Quit()
    {
        buttonClick.Play();
        Application.Quit();
    }

    
}
