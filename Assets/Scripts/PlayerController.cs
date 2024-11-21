using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public float velocidad = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float movHorizontal = Input.GetAxis("Horizontal");
            float movVertical = Input.GetAxis("Vertical");

            Vector3 desplazamiento = new Vector3(movHorizontal, 0, movVertical) * velocidad * Time.deltaTime;

            transform.Translate(desplazamiento);
        }
    }
}
