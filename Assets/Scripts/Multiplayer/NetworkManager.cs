using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    private float joinAttempt = 0;

    void Start() {
        ConnectToServer();
    }

    void ConnectToServer() {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Trying to Connect to server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server");
        base.OnConnectedToMaster();

        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("multiplayerLobby", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined the room");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
