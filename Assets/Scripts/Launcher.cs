using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;
    public Transform spawnPoint;
    void Start()
    {
        Debug.Log("Nueva funcionalidad añadida");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        //Aplicamos el nombre
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
        player.GetComponent<PhotonView>().RPC("SetNameText", RpcTarget.AllBuffered, PlayerPrefs.GetString("PlayerName"));

        //Cambiamos el color
        PlayerColor playerColor = player.GetComponent<PlayerColor>();
        if (playerColor != null)
        {
            playerColor.ChangeColor();
        }
            
    }
}
