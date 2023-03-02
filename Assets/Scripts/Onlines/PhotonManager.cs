using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    bool inRoom = false;
    bool isMatching;
    //ÉvÉåÉCÉÑÅ[ID(ã[éóéÊìæ)
    public int playerId;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void MatchingStart()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        foreach (var player in PhotonNetwork.PlayerList)
        {
            playerId = player.ActorNumber;
            inRoom = true;
            Debug.Log(playerId);
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
    }

    private void Update()
    {
        if (isMatching == true)
        {
            return;
        }
        if (inRoom == true)
        {
            if (PhotonNetwork.CurrentRoom.MaxPlayers == PhotonNetwork.CurrentRoom.PlayerCount)
            {
                isMatching = true;
                SceneManager.LoadScene("OnlineGame");
            }
        }
    }
}
