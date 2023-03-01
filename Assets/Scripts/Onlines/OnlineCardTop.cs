using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineCardTop : MonoBehaviour
{
    [SerializeField] private Card _myCard;
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
                    Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                    if (_myCard.numberTop > _enemyCard.numberBottom)
                    {
                        collision.gameObject.tag = "Player";
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(0, 0, 255, 255);
                        GameObject field = _enemyCardObject.transform.parent.gameObject;
                        Debug.Log("top");
                    }
                }
            }
            else if (collision.gameObject.tag == "Player" && _cardMove.setCard == true && _stay == false)
            {
                if (battleTop == true && _cardMove.setCard == true)
                {
                    battleTop = false;
                    Debug.Log("top2");
                }
            }
            else if (collision.gameObject.tag == "Field" && _cardMove.setCard == true && _stay == false)
            {
                if (battleTop == true && _cardMove.setCard == true)
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
                    _cardBottom.battleBottom = false;
                    _cardRight.battleRight = false;
                    _cardLeft.battleLeft = false;
                    GameObject _enemyCardObject = collision.gameObject;
                    Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                    if (_myCard.numberTop > _enemyCard.numberBottom)
                    {
                        collision.gameObject.tag = "Enemy";
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                        GameObject field = _enemyCardObject.transform.parent.gameObject;
                        field.GetComponent<DropPlace>().playerExist = false;
                        Debug.Log("top");
                    }
                }
            }
            else if (collision.gameObject.tag == "Enemy" && _cardMove.setCard == true && _stay == false)
            {
                if (battleTop == true && _cardMove.setCard == true && _stay == false)
                {
                    battleTop = false;
                    //_cardBottom.battleBottom = false;
                    //_cardRight.battleRight = false;
                    //_cardLeft.battleLeft = false;
                    Debug.Log("top2");
                }
            }
            else if (collision.gameObject.tag == "Field" && _cardMove.setCard == true && _stay == false)
            {
                if (battleTop == true && _cardMove.setCard == true && _stay == false)
                {
                    Invoke("ChangeBattleFlagLate", 1.5f);
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
