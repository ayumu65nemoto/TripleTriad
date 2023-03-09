using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OnlineCardGenerator : MonoBehaviourPunCallbacks
{
    [SerializeField] OnlineCard cardPrefab;

    //ÉJÅ[ÉhÇÃê∂ê¨
    public OnlineCard Spawn()
    {
        GameObject card = PhotonNetwork.Instantiate(cardPrefab.name, new Vector3(480, 270), Quaternion.identity);
        OnlineCard onlineCard = card.GetComponent<OnlineCard>();
        onlineCard.Set();
        return onlineCard;
    }
}
