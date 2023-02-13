using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] Card cardPrefab;

    //カードの生成
    public Card Spawn()
    {
        Card card = Instantiate(cardPrefab);
        card.Set();
        return card;
    }
}
