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

    //�J�[�h�𐶐����Ĕz��
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
            //Battler���o�R���邱�ƂŁABattler�̕��ŃJ�[�h��F���ł���
            battler.SetCardToHand(card);
        }
        battler.Hand.ResetPositions();
    }
}
