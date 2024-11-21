using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.Linq;
using Unity.VisualScripting;
using System;

public class MainMenuLauncher : MonoBehaviourPunCallbacks
{
    public TMP_InputField usernameInput;
    public TMP_Text buttonText;
    public TMP_Text warningText;

    public void OnClickConnect()
    {
        //Hacer una funcionalidad en este IF
        if (usernameInput.text.Length > 1)
        {
            if (char.IsUpper(Convert.ToChar(usernameInput.text.Substring(0, 1))))
            {
                warningText.gameObject.SetActive(false);
                warningText.text = "";
                PhotonNetwork.NickName = usernameInput.text;
                PlayerPrefs.SetString("PlayerName", usernameInput.text);
                buttonText.text = "Conectando ...";
                PhotonNetwork.ConnectUsingSettings();
            } else 
            {
                warningText.gameObject.SetActive(true);
                warningText.text = "El Nick debe debe empezar por Mayúscula";
            }
        } else
        {
            warningText.gameObject.SetActive(true);
            warningText.text = "Debe de escribir un Nick";
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Nos hemos conectado al Master");
        SceneManager.LoadScene("SceneMultiplayer");
    }
}
