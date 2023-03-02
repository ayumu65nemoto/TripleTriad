using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineCardBottom : MonoBehaviour
{
    [SerializeField] private OnlineCard _myCard;
    [SerializeField] private GameObject _myCardObject;
    [SerializeField] private OnlineCardMove _cardMove;
    [SerializeField] private OnlineCardTop _cardTop;
    [SerializeField] private OnlineCardRight _cardRight;
    [SerializeField] private OnlineCardLeft _cardLeft;
    public bool battleBottom = true;
    private bool _stay;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_myCardObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                _stay = true;
                if (battleBottom == true && _cardMove.setCard == true)
                {
                    battleBottom = false;
                    GameObject _enemyCardObject = collision.gameObject;
                    OnlineCard _enemyCard = _enemyCardObject.GetComponent<OnlineCard>();
                    if (_myCard.numberBottom > _enemyCard.numberTop)
                    {
                        collision.gameObject.tag = "Player";
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(0, 0, 255, 255);
                        GameObject field = _enemyCardObject.transform.parent.gameObject;
                        Debug.Log("bottom");
                    }
                }
            }
            else if (collision.gameObject.tag == "Player" && _cardMove.setCard == true && _stay == false)
            {
                if (battleBottom == true && _cardMove.setCard == true)
                {
                    battleBottom = false;
                    Debug.Log("bottom2");
                }
            }
            else if (collision.gameObject.tag == "Field" && _cardMove.setCard == true && _stay == false)
            {
                if (battleBottom == true && _cardMove.setCard == true)
                {
                    battleBottom = false;
                    Debug.Log("bottom3");
                }
            }
        }

        if (_myCardObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                _stay = true;
                if (battleBottom == true && _cardMove.setCard == true)
                {
                    battleBottom = false;
                    _cardTop.battleTop = false;
                    _cardRight.battleRight = false;
                    _cardLeft.battleLeft = false;
                    GameObject _enemyCardObject = collision.gameObject;
                    OnlineCard _enemyCard = _enemyCardObject.GetComponent<OnlineCard>();
                    if (_myCard.numberBottom > _enemyCard.numberTop)
                    {
                        collision.gameObject.tag = "Enemy";
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                        GameObject field = _enemyCardObject.transform.parent.gameObject;
                        field.GetComponent<DropPlace>().playerExist = false;
                        Debug.Log("bottom");
                    }
                }
            }
            else if (collision.gameObject.tag == "Enemy" && _cardMove.setCard == true && _stay == false)
            {
                if (battleBottom == true && _cardMove.setCard == true && _stay == false)
                {
                    battleBottom = false;
                    //_cardTop.battleTop = false;
                    //_cardRight.battleRight = false;
                    //_cardLeft.battleLeft = false;
                    Debug.Log("bottom2");
                }
            }
            else if (collision.gameObject.tag == "Field" && _cardMove.setCard == true && _stay == false)
            {
                if (battleBottom == true && _cardMove.setCard == true && _stay == false)
                {
                    Invoke("ChangeBattleFlagLate", 1.5f);
                    Debug.Log("bottom3");
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
        battleBottom = false;
    }
}
