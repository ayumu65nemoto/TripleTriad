using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OnlineBattlerHand : MonoBehaviourPunCallbacks, IPunObservable
{
    List<OnlineCard> list = new List<OnlineCard>();
    public float posX;
    public float posY;

    public void Add(OnlineCard card)
    {
        list.Add(card);
        card.transform.SetParent(transform);
    }

    public void Remove(OnlineCard card)
    {
        list.Remove(card);
    }

    public void ResetPositions()
    {
        for (int i = 0; i < list.Count; i++)
        {
            posX = 0;
            posY = (i - list.Count / 2f) * 150f + 60;
            list[i].transform.localPosition = new Vector3(posX, posY);
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //データの送信
            stream.SendNext(posY);
            stream.SendNext(posY);
        }
        else
        {
            //データの受信
            posX = (float)stream.ReceiveNext();
            posY = (float)stream.ReceiveNext();
        }
    }
}
