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
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_myCardObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                if (battleRight == true && _cardMove.setCard == true)
                {
                    GameObject _enemyCardObject = collision.gameObject;
                    Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                    if (_myCard.numberRight > _enemyCard.numberLeft)
                    {
                        collision.gameObject.tag = "Player";
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(0, 0, 255, 255);
                        GameObject field = _enemyCardObject.transform.parent.gameObject;
                        field.GetComponent<DropPlace>().playerExist = true;
                    }
                    battleRight = false;
                    _cardTop.battleTop = false;
                    _cardBottom.battleBottom = false;
                    _cardLeft.battleLeft = false;
                }
            }
        }

        if (_myCardObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                if (battleRight == true && _cardMove.setCard == true)
                {
                    GameObject _enemyCardObject = collision.gameObject;
                    Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                    if (_myCard.numberRight > _enemyCard.numberLeft)
                    {
                        collision.gameObject.tag = "Enemy";
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                        GameObject field = _enemyCardObject.transform.parent.gameObject;
                        field.GetComponent<DropPlace>().playerExist = false;
                    }
                    battleRight = false;
                    _cardTop.battleTop = false;
                    _cardBottom.battleBottom = false;
                    _cardLeft.battleLeft = false;
                }
            }
        }
    }
}
