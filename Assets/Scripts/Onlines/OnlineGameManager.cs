using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineGameManager : MonoBehaviour
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

    private GameObject[] _playerCards;
    [SerializeField] GameObject playerCanvas1;
    [SerializeField] GameObject playerCanvas2;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    [SerializeField] GameObject winText2;
    [SerializeField] GameObject loseText2;

    [SerializeField] GameObject replay;
    [SerializeField] GameObject back;

    //ターンフラグ
    public bool turn;
    //ゲーム終了フラグ
    public bool gameSet;

    private OnlineDropPlace _set;
    private OnlineDropPlace _set1;
    private OnlineDropPlace _set2;
    private OnlineDropPlace _set3;
    private OnlineDropPlace _set4;
    private OnlineDropPlace _set5;
    private OnlineDropPlace _set6;
    private OnlineDropPlace _set7;
    private OnlineDropPlace _set8;

    //PhotonManager取得
    private GameObject _gameObject;
    private PhotonManager _photonManager;

    private void Start()
    {
        RandomBool();
        SetUp();
        gameSet = false;

        _set = _cardPosition.GetComponent<OnlineDropPlace>();
        _set1 = _cardPosition1.GetComponent<OnlineDropPlace>();
        _set2 = _cardPosition2.GetComponent<OnlineDropPlace>();
        _set3 = _cardPosition3.GetComponent<OnlineDropPlace>();
        _set4 = _cardPosition4.GetComponent<OnlineDropPlace>();
        _set5 = _cardPosition5.GetComponent<OnlineDropPlace>();
        _set6 = _cardPosition6.GetComponent<OnlineDropPlace>();
        _set7 = _cardPosition7.GetComponent<OnlineDropPlace>();
        _set8 = _cardPosition8.GetComponent<OnlineDropPlace>();

        _gameObject = GameObject.Find("PhotonManager");
        _photonManager = _gameObject.GetComponent<PhotonManager>();
    }

    private void Update()
    {
        if (_set.exist == true && _set1.exist == true && _set2.exist == true && _set3.exist == true && _set4.exist == true && _set5.exist == true && _set6.exist == true && _set7.exist == true && _set8.exist == true)
        {
            gameSet = true;
            Invoke("GameSet", 1.5f);
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

    private void GameSet()
    {
        _playerCards = GameObject.FindGameObjectsWithTag("Player");
        if (_photonManager.playerId == 1)
        {
            playerCanvas1.SetActive(true);
        }
        if (_photonManager.playerId == 2)
        {
            playerCanvas2.SetActive(true);
        }

        if (_playerCards.Length > 4)
        {
            winText.SetActive(true);
            loseText2.SetActive(true);
        }
        else
        {
            loseText.SetActive(true);
            winText2.SetActive(true);
        }
        replay.SetActive(true);
        back.SetActive(true);
    }
}
