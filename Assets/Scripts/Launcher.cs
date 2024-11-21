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
<<<<<<< HEAD
        Debug.Log("Correcion de Bug");
=======
        Debug.Log("Nueva funcionalidad a�adida");
>>>>>>> nueva-funcionalidad
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
