using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Battler player;
    [SerializeField] Battler enemy;
    [SerializeField] CardGenerator cardGenerator;
    [SerializeField] GameObject _cardPosition;
    [SerializeField] GameObject _cardPosition1;
    [SerializeField] GameObject _cardPosition2;
    [SerializeField] GameObject _cardPosition3;
    [SerializeField] GameObject _cardPosition4;
    [SerializeField] GameObject _cardPosition5;
    [SerializeField] GameObject _cardPosition6;
    [SerializeField] GameObject _cardPosition7;
    [SerializeField] GameObject _cardPosition8;

    public bool turn;
    public bool gameSet;
    private DropPlace _set;
    private DropPlace _set1;
    private DropPlace _set2;
    private DropPlace _set3;
    private DropPlace _set4;
    private DropPlace _set5;
    private DropPlace _set6;
    private DropPlace _set7;
    private DropPlace _set8;

    private void Start()
    {
        RandomBool();
        SetUp();
        gameSet = false;
        _set = _cardPosition.GetComponent<DropPlace>();
        _set1 = _cardPosition1.GetComponent<DropPlace>();
        _set2 = _cardPosition2.GetComponent<DropPlace>();
        _set3 = _cardPosition3.GetComponent<DropPlace>();
        _set4 = _cardPosition4.GetComponent<DropPlace>();
        _set5 = _cardPosition5.GetComponent<DropPlace>();
        _set6 = _cardPosition6.GetComponent<DropPlace>();
        _set7 = _cardPosition7.GetComponent<DropPlace>();
        _set8 = _cardPosition7.GetComponent<DropPlace>();
    }

    private void Update()
    {
        if (_set.exist == true && _set1.exist == true && _set2.exist == true && _set3.exist == true && _set4.exist == true && _set5.exist == true && _set6.exist == true && _set7.exist == true && _set8.exist == true)
        {
            gameSet = true;
        }
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
