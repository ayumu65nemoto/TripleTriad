using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OnlineBattlerHand : MonoBehaviourPunCallbacks
{
    public float posX;
    public float posY;

    public void ResetPositions(float px, float py, OnlineCard card)
    {
        posX = px;
        posY = 860 - (py * 150f);
        card.transform.position = new Vector3(posX, posY);
    }
}
