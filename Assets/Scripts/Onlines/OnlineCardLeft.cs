using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineCardLeft : MonoBehaviour
{
    [SerializeField] private OnlineCard _myCard;
    [SerializeField] private GameObject _myCardObject;
    [SerializeField] private OnlineCardMove _cardMove;
    [SerializeField] private OnlineCardTop _cardTop;
    [SerializeField] private OnlineCardBottom _cardBottom;
    [SerializeField] private OnlineCardRight _cardRight;
    public bool battleLeft = true;
    private bool _stay;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_myCardObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                _stay = true;
                if (battleLeft == true && _cardMove.setCard == true)
                {
                    battleLeft = false;
                    GameObject _enemyCardObject = collision.gameObject;
                    OnlineCard _enemyCard = _enemyCardObject.GetComponent<OnlineCard>();
                    if (_myCard.numberLeft > _enemyCard.numberRight)
                    {
                        Transform canvas = _enemyCard.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(0, 0, 255, 255);
                        Debug.Log(canvas);
                        Debug.Log("left");
                    }
                }
            }
            else if (collision.gameObject.tag == "Player" && _cardMove.setCard == true && _stay == false)
            {
                if (battleLeft == true && _cardMove.setCard == true)
                {
                    battleLeft = false;
                    Debug.Log("left2");
                }
            }
            else if (collision.gameObject.tag == "Field" && _cardMove.setCard == true && _stay == false)
            {
                if (battleLeft == true && _cardMove.setCard == true)
                {
                    battleLeft = false;
                    Debug.Log("left3");
                }
            }
        }

        if (_myCardObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                _stay = true;
                if (battleLeft == true && _cardMove.setCard == true)
                {
                    battleLeft = false;
                    _cardTop.battleTop = false;
                    _cardBottom.battleBottom = false;
                    _cardRight.battleRight = false;
                    GameObject _enemyCardObject = collision.gameObject;
                    OnlineCard _enemyCard = _enemyCardObject.GetComponent<OnlineCard>();
                    if (_myCard.numberLeft > _enemyCard.numberRight)
                    {
                        Transform canvas = _enemyCard.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                        Debug.Log(canvas);
                        Debug.Log("left");
                    }
                }
            }
            else if (collision.gameObject.tag == "Enemy" && _cardMove.setCard == true && _stay == false)
            {
                if (battleLeft == true && _cardMove.setCard == true && _stay == false)
                {
                    battleLeft = false;
                    //_cardTop.battleTop = false;
                    //_cardBottom.battleBottom = false;
                    //_cardRight.battleRight = false;
                    Debug.Log("left2");
                }
            }
            else if (collision.gameObject.tag == "Field" && _cardMove.setCard == true && _stay == false)
            {
                if (battleLeft == true && _cardMove.setCard == true && _stay == false)
                {
                    Invoke("ChangeBattleFlagLate", 1.5f);
                    Debug.Log("left3");
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
        battleLeft = false;
    }
}
