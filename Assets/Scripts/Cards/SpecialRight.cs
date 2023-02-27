using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialRight : MonoBehaviour
{
    [SerializeField] private Card _myCard;
    [SerializeField] private GameObject _myCardObject;
    [SerializeField] private CardMove _cardMove;
    [SerializeField] private SpecialTop _specialTop;
    [SerializeField] private SpecialBottom _specialBottom;
    [SerializeField] private SpecialLeft _specialLeft;
    public bool sameRight = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_myCardObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameObject _enemyCardObject = collision.gameObject;
                Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                if (_myCard.numberRight == _enemyCard.numberLeft && _cardMove.setCard == true)
                {
                    sameRight = true;
                    if (sameRight == true && _specialTop.sameTop == true || sameRight == true && _specialBottom.sameBottom == true || sameRight == true && _specialLeft.sameLeft == true)
                    {
                        collision.gameObject.tag = "Player";
                        CardTop cardTop = collision.transform.Find("Top").GetComponent<CardTop>();
                        cardTop.battleTop = true;
                        CardBottom cardBottom = collision.transform.Find("Bottom").GetComponent<CardBottom>();
                        cardBottom.battleBottom = true;
                        CardRight cardRight = collision.transform.Find("Right").GetComponent<CardRight>();
                        cardRight.battleRight = true;
                        CardLeft cardLeft = collision.transform.Find("Left").GetComponent<CardLeft>();
                        cardLeft.battleLeft = true;
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(0, 0, 255, 255);
                        GameObject field = _enemyCardObject.transform.parent.gameObject;
                        field.GetComponent<DropPlace>().playerExist = true;
                        Debug.Log("b3");
                    }
                    Invoke("ChangeSameFlagLate", 2f);
                }
            }
        }

        if (_myCardObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                GameObject _enemyCardObject = collision.gameObject;
                Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                if (_myCard.numberRight == _enemyCard.numberLeft && _cardMove.setCard == true)
                {
                    sameRight = true;
                    if (sameRight == true && _specialTop.sameTop == true || sameRight == true && _specialBottom.sameBottom == true || sameRight == true && _specialLeft.sameLeft == true)
                    {
                        collision.gameObject.tag = "Enemy";
                        CardTop cardTop = collision.transform.Find("Top").GetComponent<CardTop>();
                        cardTop.battleTop = true;
                        CardBottom cardBottom = collision.transform.Find("Bottom").GetComponent<CardBottom>();
                        cardBottom.battleBottom = true;
                        CardRight cardRight = collision.transform.Find("Right").GetComponent<CardRight>();
                        cardRight.battleRight = true;
                        CardLeft cardLeft = collision.transform.Find("Left").GetComponent<CardLeft>();
                        cardLeft.battleLeft = true;
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                        GameObject field = _enemyCardObject.transform.parent.gameObject;
                        field.GetComponent<DropPlace>().playerExist = false;
                        Debug.Log("b3");
                    }
                    Invoke("ChangeSameFlagLate", 2f);
                }
            }
        }
    }

    private void ChangeSameFlagLate()
    {
        sameRight = false;
    }
}
