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
        for (int i = 0; i < 5; i++)
        {
            Card card = cardGenerator.Spawn();
            player.Hand.Add(card);
        }
        player.Hand.ResetPositions();
    }
}
