using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineCardTop : MonoBehaviour
{
    [SerializeField] private OnlineCard _myCard;
    [SerializeField] private GameObject _myCardObject;
    [SerializeField] private OnlineCardMove _cardMove;
    [SerializeField] private OnlineCardBottom _cardBottom;
    [SerializeField] private OnlineCardRight _cardRight;
    [SerializeField] private OnlineCardLeft _cardLeft;
    public bool battleTop = true;
    private bool _stay = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_myCardObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                _stay = true;
                if (battleTop == true && _cardMove.setCard == true)
                {
                    battleTop = false;
                    GameObject _enemyCardObject = collision.gameObject;
                    OnlineCard _enemyCard = _enemyCardObject.GetComponent<OnlineCard>();
                    if (_myCard.numberTop > _enemyCard.numberBottom)
                    {
                        Transform canvas = _enemyCard.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color(0, 0, 1, 1);
                        collision.tag = "Player";
                        _myCard.ChangeTag("Player");
                        Debug.Log("top");
                    }
                }
            }
            else if (collision.gameObject.tag == "Field" && _cardMove.setCard == true && _stay == false)
            {
                if (battleTop == true)
                {
                    battleTop = false;
                    Debug.Log("top3");
                }
            }
        }

        if (_myCardObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                _stay = true;
                if (battleTop == true && _cardMove.setCard == true)
                {
                    battleTop = false;
                    GameObject _enemyCardObject = collision.gameObject;
                    OnlineCard _enemyCard = _enemyCardObject.GetComponent<OnlineCard>();
                    if (_myCard.numberTop > _enemyCard.numberBottom)
                    {
                        Transform canvas = _enemyCard.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color(1, 0, 0, 1);
                        collision.tag = "Enemy";
                        _myCard.ChangeTag("Enemy");
                        Debug.Log("top");
                    }
                }
            }
            else if (collision.gameObject.tag == "Field" && _cardMove.setCard == true && _stay == false)
            {
                if (battleTop == true && _cardMove.setCard == true && _stay == false)
                {
                    battleTop = false;
                    Debug.Log("top3");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_myCardObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                _stay = false;
            }
        }

        if (_myCardObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                _stay = false;
            }
        }
    }

    private void ChangeBattleFlagLate()
    {
        battleTop = false;
    }
}
