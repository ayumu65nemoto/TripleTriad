using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTop : MonoBehaviour
{
    [SerializeField] private Card _myCard;
    [SerializeField] private GameObject _myCardObject;
    [SerializeField] private CardMove _cardMove;
    public bool battleTop = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("col");
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
            }
        }
    }
}
