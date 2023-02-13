using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Battler player;
    [SerializeField] Battler enemy;
    [SerializeField] CardGenerator cardGenerator;

    private void Start()
    {
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
        }
        battler.Hand.ResetPositions();
    }
}
