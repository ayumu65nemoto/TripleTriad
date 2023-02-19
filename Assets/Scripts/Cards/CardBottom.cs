using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardBottom : MonoBehaviour
{
    [SerializeField] private Card _myCard;
    [SerializeField] private GameObject _myCardObject;
    [SerializeField] private CardMove _cardMove;
    [SerializeField] private CardTop _cardTop;
    [SerializeField] private CardRight _cardRight;
    [SerializeField] private CardLeft _cardLeft;
    public bool battleBottom = true;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_myCardObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                if (battleBottom == true && _cardMove.setCard == true)
                {
                    GameObject _enemyCardObject = collision.gameObject;
                    Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                    if (_myCard.numberBottom > _enemyCard.numberTop)
                    {
                        collision.gameObject.tag = "Player";
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(0, 0, 255, 255);
                        GameObject field = _enemyCardObject.transform.parent.gameObject;
                        field.GetComponent<DropPlace>().playerExist = true;
                    }
                    battleBottom = false;
                    _cardTop.battleTop = false;
                    _cardRight.battleRight = false;
                    _cardLeft.battleLeft = false;
                }
            }
        }

        if (_myCardObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                if (battleBottom == true && _cardMove.setCard == true)
                {
                    GameObject _enemyCardObject = collision.gameObject;
                    Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                    if (_myCard.numberBottom > _enemyCard.numberTop)
                    {
                        collision.gameObject.tag = "Enemy";
                        Transform canvas = _enemyCardObject.transform.Find("Canvas");
                        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                        GameObject field = _enemyCardObject.transform.parent.gameObject;
                        field.GetComponent<DropPlace>().playerExist = false;
                    }
                    battleBottom = false;
                    _cardTop.battleTop = false;
                    _cardRight.battleRight = false;
                    _cardLeft.battleLeft = false;
                }
            }
        }
    }
}
