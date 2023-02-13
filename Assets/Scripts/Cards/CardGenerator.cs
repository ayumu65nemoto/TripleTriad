using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] Card cardPrefab;

    //ƒJ[ƒh‚Ì¶¬
    public Card Spawn()
    {
        Card card = Instantiate(cardPrefab);
        card.Set();
        return card;
    }
}
