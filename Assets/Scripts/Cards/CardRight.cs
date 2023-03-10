using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardRight : MonoBehaviour
{
    [SerializeField] private Card _myCard;
    [SerializeField] private GameObject _myCardObject;
    [SerializeField] private CardMove _cardMove;
    [SerializeField] private CardTop _cardTop;
    [SerializeField] private CardBottom _cardBottom;
    [SerializeField] private CardLeft _cardLeft;
    public bool battleRight = true;
    private bool _stay;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_myCardObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                _stay = true;
                if (battleRight == true && _cardMove.setCard == true)
                {
                    battleRight = false;
                    GameObject _enemyCardObject = collision.gameObject;
                    Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                    if (_myCard.numberRight > _enemyCard.numberLeft)
                    {
                        collision.gameObject.tag = "Player";
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(0, 0, 255, 255);
                        GameObject field = _enemyCardObject.transform.parent.gameObject;
                        field.GetComponent<DropPlace>().playerExist = true;
                        Debug.Log("right");
                    }
                }
            }
            else if (collision.gameObject.tag == "Player" && _cardMove.setCard == true && _stay == false)
            {
                if (battleRight == true && _cardMove.setCard == true)
                {
                    battleRight = false;
                    Debug.Log("right2");
                }
            }
            else if (collision.gameObject.tag == "Field" && _cardMove.setCard == true && _stay == false)
            {
                if (battleRight == true && _cardMove.setCard == true)
                {
                    battleRight = false;
                    Debug.Log("right3");
                }
            }
        }

        if (_myCardObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                _stay = true;
                if (battleRight == true && _cardMove.setCard == true)
                {
                    battleRight = false;
                    _cardTop.battleTop = false;
                    _cardBottom.battleBottom = false;
                    _cardLeft.battleLeft = false;
                    GameObject _enemyCardObject = collision.gameObject;
                    Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                    if (_myCard.numberRight > _enemyCard.numberLeft)
                    {
                        collision.gameObject.tag = "Enemy";
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                        GameObject field = _enemyCardObject.transform.parent.gameObject;
                        field.GetComponent<DropPlace>().playerExist = false;
                        Debug.Log("right");
                    }
                }
            }
            else if (collision.gameObject.tag == "Enemy" && _cardMove.setCard == true && _stay == false)
            {
                if (battleRight == true && _cardMove.setCard == true && _stay == false)
                {
                    battleRight = false;
                    //_cardTop.battleTop = false;
                    //_cardBottom.battleBottom = false;
                    //_cardLeft.battleLeft = false;
                    Debug.Log("right2");
                }
            }
            else if (collision.gameObject.tag == "Field" && _cardMove.setCard == true && _stay == false)
            {
                if (battleRight == true && _cardMove.setCard == true && _stay == false)
                {
                    Invoke("ChangeBattleFlagLate", 1.5f);
                    Debug.Log("right3");
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
        battleRight = false;
    }
}
