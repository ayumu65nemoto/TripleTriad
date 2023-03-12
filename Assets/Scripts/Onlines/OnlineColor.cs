using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class OnlineColor : MonoBehaviourPunCallbacks, IPunObservable
{
    private float r_color;
    private float g_color;
    private float b_color;
    private float a_color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (r_color == 1 && b_color == 0)
        //{
        //    GameObject card = transform.parent.parent.gameObject;
        //    card.tag = "Enemy";
        //    Debug.Log(gameObject.GetComponent<Image>().color);
        //}
        //if (b_color == 1 && r_color == 0)
        //{
        //    GameObject card = transform.parent.parent.gameObject;
        //    card.tag = "Player";
        //    Debug.Log(gameObject.GetComponent<Image>().color);
        //}
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //データの送信
            stream.SendNext(gameObject.GetComponent<Image>().color.r);
            stream.SendNext(gameObject.GetComponent<Image>().color.g);
            stream.SendNext(gameObject.GetComponent<Image>().color.b);
            stream.SendNext(gameObject.GetComponent<Image>().color.a);
        }
        else
        {
            //データの受信
            r_color = (float)stream.ReceiveNext();
            g_color = (float)stream.ReceiveNext();
            b_color = (float)stream.ReceiveNext();
            a_color = (float)stream.ReceiveNext();
            gameObject.GetComponent<Image>().color = new Color(r_color, g_color, b_color, a_color);
        }
    }
}
