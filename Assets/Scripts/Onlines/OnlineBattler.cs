using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineBattler : MonoBehaviour
{
    [SerializeField] OnlineBattlerHand hand;

    public OnlineBattlerHand Hand { get => hand; }

    public void SetCardToHand(OnlineCard card)
    {
        //hand.Add(card);
    }
}
