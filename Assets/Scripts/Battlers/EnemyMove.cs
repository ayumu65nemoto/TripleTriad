using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject _enemyHandField;
    [SerializeField] GameObject _cardPosition;
    [SerializeField] GameObject _cardPosition1;
    [SerializeField] GameObject _cardPosition2;
    [SerializeField] GameObject _cardPosition3;
    [SerializeField] GameObject _cardPosition4;
    [SerializeField] GameObject _cardPosition5;
    [SerializeField] GameObject _cardPosition6;
    [SerializeField] GameObject _cardPosition7;
    [SerializeField] GameObject _cardPosition8;

    //変数格納用
    [SerializeField] private GameObject[] _cards;
    //[SerializeField] private GameObject[] _tops;
    //[SerializeField] private GameObject[] _bottoms;
    //[SerializeField] private GameObject[] _rights;
    //[SerializeField] private GameObject[] _lefts;

    //for文制御フラグ
    private bool _setFlag;

    private void Update()
    {
        if (_gameManager.turn == false)
        {
            EnemyCardSet();
        }
    }

    void EnemyCardSet()
    {
        if (_cardPosition.GetComponent<DropPlace>().exist == true)
        {
            _setFlag = true;
            for (int i = 0; i < _enemyHandField.transform.childCount; i++)
            {
                Card card = _cardPosition.transform.GetChild(0).gameObject.GetComponent<Card>();
                _cards[i] = _enemyHandField.transform.GetChild(i).gameObject;
                if (_cards[i].GetComponent<Card>().numberRight > card.numberLeft && _cardPosition3.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition3.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition3);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberTop > card.numberBottom && _cardPosition1.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition1.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition1);
                    _setFlag = false;
                }
            }
        }
        else if (_cardPosition1.GetComponent<DropPlace>().exist == true)
        {
            _setFlag = true;
            for (int i = 0; i < _enemyHandField.transform.childCount; i++)
            {
                Card card = _cardPosition1.transform.GetChild(0).gameObject.GetComponent<Card>();
                _cards[i] = _enemyHandField.transform.GetChild(i).gameObject;
                if (_cards[i].GetComponent<Card>().numberRight > card.numberLeft && _cardPosition4.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition4.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition4);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberTop > card.numberBottom && _cardPosition2.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition2.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition2);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberBottom > card.numberTop && _cardPosition.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition);
                    _setFlag = false;
                }
            }
        }
        else if (_cardPosition2.transform != null)
        {

        }
        else if (_cardPosition3.transform != null)
        {

        }
        else if (_cardPosition4.transform != null)
        {
            
        }
        else if (_cardPosition5.transform != null)
        {

        }
        else if (_cardPosition6.transform != null)
        {

        }
        else if (_cardPosition7.transform != null)
        {

        }
        else if (_cardPosition8.transform != null)
        {

        }
        else
        {
            for (int i = 0; i < _enemyHandField.transform.childCount; i++)
            {
                _cards[i] = _enemyHandField.transform.GetChild(i).gameObject;
                _cards[i].transform.position = new Vector3(440, 310);
            }
        }
    }

    private void EnemySetCard(GameObject gameObject, GameObject gameObject1)
    {
        //カードの親をフィールドに
        gameObject.transform.SetParent(gameObject1.transform);
        //カードの位置を親(フィールド)の０の位置に設定
        gameObject.transform.localPosition = Vector3.zero;
        //カード設置フラグとカード存在フラグを立てる
        gameObject.GetComponent<CardMove>().setCard = true;
        //ターンを交代する
        _gameManager.turn = !_gameManager.turn;

        //プレイヤーのカードなら青に、エネミーのカードなら赤に変える
        if (gameObject.tag == "Player")
        {
            Transform canvas = gameObject.transform.Find("Canvas");
            canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(0, 0, 255, 255);
        }
        else if (gameObject.tag == "Enemy")
        {
            Transform canvas = gameObject.transform.Find("Canvas");
            canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
    }
}
