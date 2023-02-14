using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlerHand : MonoBehaviour
{
    List<Card> list = new List<Card>();

    public void Add(Card card)
    {
        list.Add(card);
        card.transform.SetParent(transform);
    }

    public void Remove(Card card)
    {
        list.Remove(card);
    }

    public void ResetPositions()
    {
        for (int i = 0; i < list.Count; i++)
        {
            float posY = (i - list.Count / 2f) * 60f + 20;
            list[i].transform.localPosition = new Vector3(0, posY);
        }
    }
}
