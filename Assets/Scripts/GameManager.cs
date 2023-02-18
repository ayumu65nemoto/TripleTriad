using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Battler player;
    [SerializeField] Battler enemy;
    [SerializeField] CardGenerator cardGenerator;

    public bool turn;

    private void Start()
    {
        RandomBool();
        SetUp();
    }

    //カードを生成して配る
    void SetUp()
    {
        SendCardsTo(player);
        SendCardsTo(enemy);
    }

    void SendCardsTo(Battler battler)
    {
        for (int i = 0; i < 5; i++)
        {
            Card card = cardGenerator.Spawn();
            //Battlerを経由することで、Battlerの方でカードを認識できる
            battler.SetCardToHand(card);

            //どちらの手札にあるかによってタグを付ける
            if (battler == player)
            {
                card.tag = "Player";
            }
            else if (battler == enemy)
            {
                card.tag = "Enemy";
            }
        }
        battler.Hand.ResetPositions();
    }

    void RandomBool()
    {
        int r = Random.Range(0, 2);
        if (r == 0)
        {
            turn = true;
        }
        else
        {
            turn = false;
        }
    }
}
