using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTop : MonoBehaviour
{
    [SerializeField] private Card _myCard;
    [SerializeField] private GameObject _myCardObject;
    [SerializeField] private CardMove _cardMove;
    [SerializeField] private CardBottom _cardBottom;
    [SerializeField] private CardRight _cardRight;
    [SerializeField] private CardLeft _cardLeft;
    public bool battleTop = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_myCardObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                if (battleTop == true && _cardMove.setCard == true)
                {
                    GameObject _enemyCardObject = collision.gameObject;
                    Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                    if (_myCard.numberTop > _enemyCard.numberBottom)
                    {
                        collision.gameObject.tag = "Player";
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(0, 0, 255, 255);
                    }
                    battleTop = false;
                    _cardBottom.battleBottom = false;
                    _cardRight.battleRight = false;
                    _cardLeft.battleLeft = false;
                }
            }
        }

        if (_myCardObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                if (battleTop == true && _cardMove.setCard == true)
                {
                    GameObject _enemyCardObject = collision.gameObject;
                    Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                    if (_myCard.numberTop > _enemyCard.numberBottom)
                    {
                        collision.gameObject.tag = "Enemy";
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                    }
                    battleTop = false;
                    _cardBottom.battleBottom = false;
                    _cardRight.battleRight = false;
                    _cardLeft.battleLeft = false;
                }
            }
        }
    }
}