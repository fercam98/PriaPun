using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class PlayerName : MonoBehaviourPunCallbacks
{
    public TMP_Text playerName;


    [PunRPC]
    public void SetNameText(string name)
    {
        playerName.text = name;
    }
}
