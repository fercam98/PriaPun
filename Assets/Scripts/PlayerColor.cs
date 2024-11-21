using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class PlayerColor : MonoBehaviourPunCallbacks
{
    private Renderer myRenderer;
    private MaterialPropertyBlock propBlock;

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
        if (myRenderer != null)
        {
            //Clonar el material para asegurarse de cada instancia tenga su propio material
            myRenderer.material = new Material(myRenderer.material);
        }
        propBlock = new MaterialPropertyBlock();
    }

    void Start()
    {
        if (photonView.IsMine)
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        StartCoroutine(ChangeColorAfterDelay());
    }

    private IEnumerator ChangeColorAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Color newColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        photonView.RPC("UpdateColor", RpcTarget.AllBuffered, newColor.r, newColor.g, newColor.b);
    }

    [PunRPC]
    void UpdateColor(float r, float g, float b)
    {
        Debug.Log("RPC Received - Updating Color");
        ApplyColor(new Color(r, g, b));
    }

    private void ApplyColor(Color color)
    {
        Debug.Log("Aplicando Color: " + color);
        if (myRenderer != null)
        {
            myRenderer.GetPropertyBlock(propBlock);
            propBlock.SetColor("_Color", color);
            myRenderer.SetPropertyBlock(propBlock);
        } else
        {
            Debug.LogError("Render not found on " + gameObject.name);
        }
    }
}
