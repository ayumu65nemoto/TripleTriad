using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialTop : MonoBehaviour
{
    [SerializeField] private Card _myCard;
    [SerializeField] private GameObject _myCardObject;
    [SerializeField] private CardMove _cardMove;
    [SerializeField] private SpecialBottom _specialBottom;
    [SerializeField] private SpecialRight _specialRight;
    [SerializeField] private SpecialLeft _specialLeft;
    public bool sameTop = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_myCardObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameObject _enemyCardObject = collision.gameObject;
                Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                if (_myCard.numberTop == _enemyCard.numberBottom && _cardMove.setCard == true)
                {
                    sameTop = true;
                    Debug.Log("a");
                    if (sameTop == true && _specialBottom.sameBottom == true || sameTop == true && _specialRight.sameRight == true || sameTop == true && _specialLeft.sameLeft == true)
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
                        Debug.Log("b");
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
                if (_myCard.numberTop == _enemyCard.numberBottom && _cardMove.setCard == true)
                {
                    sameTop = true;
                    if (sameTop == true && _specialBottom.sameBottom == true || sameTop == true && _specialRight.sameRight == true || sameTop == true && _specialLeft.sameLeft == true)
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
                        Debug.Log("b");
                    }
                    Invoke("ChangeSameFlagLate", 2f);
                }
            }
        }
    }

    private void ChangeSameFlagLate()
    {
        sameTop = false;
    }
}
