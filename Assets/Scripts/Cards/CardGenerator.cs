using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        Card card = Instantiate(cardPrefab);
        card.Set();
    }
}
