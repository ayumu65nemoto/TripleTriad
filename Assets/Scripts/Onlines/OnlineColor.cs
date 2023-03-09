using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class OnlineColor : MonoBehaviourPunCallbacks, IPunObservable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Debug.Log("send");
        }
        else
        {
            //データの受信
            float r = (float)stream.ReceiveNext();
            float g = (float)stream.ReceiveNext();
            float b = (float)stream.ReceiveNext();
            float a = (float)stream.ReceiveNext();
            Debug.Log("receive");
            gameObject.GetComponent<Image>().color = new Vector4(r, g, b, a);

            if (r == 1 && b == 0)
            {
                GameObject card = transform.parent.parent.gameObject;
                card.tag = "Enemy";
            }
            if (b == 1 && r == 0)
            {
                GameObject card = transform.parent.parent.gameObject;
                card.tag = "Player";
            }
        }
    }
}
