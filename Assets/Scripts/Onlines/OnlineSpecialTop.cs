using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineSpecialTop : MonoBehaviour
{
    [SerializeField] private OnlineCard _myCard;
    [SerializeField] private GameObject _myCardObject;
    [SerializeField] private OnlineCardMove _cardMove;
    [SerializeField] private OnlineSpecialBottom _specialBottom;
    [SerializeField] private OnlineSpecialRight _specialRight;
    [SerializeField] private OnlineSpecialLeft _specialLeft;
    public bool sameTop = false;
    public bool plusFlagTop = false;
    public int plusTop;
    private int _plusCount = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_myCardObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameObject _enemyCardObject = collision.gameObject;
                OnlineCard _enemyCard = _enemyCardObject.GetComponent<OnlineCard>();
                OnlineCardMove _enemyCardMove = _enemyCardObject.GetComponent<OnlineCardMove>();
                Debug.Log(_enemyCardObject);
                Debug.Log(_enemyCardMove);
                if (_enemyCardMove.setCard == true)
                {
                    if (_myCard.numberTop == _enemyCard.numberBottom && _cardMove.setCard == true)
                    {
                        sameTop = true;
                        Debug.Log("a");
                        if (sameTop == true && _specialBottom.sameBottom == true || sameTop == true && _specialRight.sameRight == true || sameTop == true && _specialLeft.sameLeft == true)
                        {
                            SpecialPlayerAction(collision, _enemyCardObject);
                            Debug.Log("b");
                        }
                        Invoke("ChangeSameFlagLate", 2f);
                    }

                    if (_cardMove.setCard == true && _plusCount > 0)
                    {
                        plusTop = _myCard.numberTop + _enemyCard.numberBottom;
                        plusFlagTop = true;
                        Invoke("ChangePlusFlagLate", 2f);
                        _plusCount--;
                        Debug.Log("plusTopEnter");
                    }

                    if (plusTop == _specialBottom.plusBottom || plusTop == _specialRight.plusRight || plusTop == _specialLeft.plusLeft)
                    {
                        if (plusFlagTop == true)
                        {
                            SpecialPlayerAction(collision, _enemyCardObject);
                            plusFlagTop = false;
                            Debug.Log("plusTop");
                        }
                    }
                }
            }
        }

        if (_myCardObject.tag == "Enemy")
        {
            if (collision.gameObject.tag == "Player")
            {
                GameObject _enemyCardObject = collision.gameObject;
                OnlineCard _enemyCard = _enemyCardObject.GetComponent<OnlineCard>();
                OnlineCardMove _enemyCardMove = _enemyCardObject.GetComponent<OnlineCardMove>();
                if (_enemyCardMove.setCard == true)
                {
                    if (_myCard.numberTop == _enemyCard.numberBottom && _cardMove.setCard == true)
                    {
                        sameTop = true;
                        if (sameTop == true && _specialBottom.sameBottom == true || sameTop == true && _specialRight.sameRight == true || sameTop == true && _specialLeft.sameLeft == true)
                        {
                            SpecialEnemyAction(collision, _enemyCardObject);
                            Debug.Log("b");
                        }
                        Invoke("ChangeSameFlagLate", 2f);
                    }

                    if (_cardMove.setCard == true && _plusCount > 0)
                    {
                        plusTop = _myCard.numberTop + _enemyCard.numberBottom;
                        plusFlagTop = true;
                        Invoke("ChangePlusFlagLate", 2f);
                        _plusCount--;
                        Debug.Log("plusTopEnter2");
                    }

                    if (plusTop == _specialBottom.plusBottom || plusTop == _specialRight.plusRight || plusTop == _specialLeft.plusLeft)
                    {
                        if (plusFlagTop == true)
                        {
                            SpecialEnemyAction(collision, _enemyCardObject);
                            plusFlagTop = false;
                            Debug.Log("plusTop2");
                        }
                    }
                }
            }
        }
    }

    private void ChangeSameFlagLate()
    {
        sameTop = false;
    }

    private void ChangePlusFlagLate()
    {
        plusFlagTop = false;
    }

    public void SpecialPlayerAction(Collider2D collision, GameObject _enemyCardObject)
    {
        collision.gameObject.tag = "Player";
        OnlineCardTop cardTop = collision.transform.Find("Top").GetComponent<OnlineCardTop>();
        cardTop.battleTop = true;
        OnlineCardBottom cardBottom = collision.transform.Find("Bottom").GetComponent<OnlineCardBottom>();
        cardBottom.battleBottom = true;
        OnlineCardRight cardRight = collision.transform.Find("Right").GetComponent<OnlineCardRight>();
        cardRight.battleRight = true;
        OnlineCardLeft cardLeft = collision.transform.Find("Left").GetComponent<OnlineCardLeft>();
        cardLeft.battleLeft = true;
        Transform canvas = _enemyCardObject.transform.Find("Canvas");
        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(0, 0, 255, 255);
        _myCard.ChangeTag("Player");
    }

    public void SpecialEnemyAction(Collider2D collision, GameObject _enemyCardObject)
    {
        collision.gameObject.tag = "Enemy";
        OnlineCardTop cardTop = collision.transform.Find("Top").GetComponent<OnlineCardTop>();
        cardTop.battleTop = true;
        OnlineCardBottom cardBottom = collision.transform.Find("Bottom").GetComponent<OnlineCardBottom>();
        cardBottom.battleBottom = true;
        OnlineCardRight cardRight = collision.transform.Find("Right").GetComponent<OnlineCardRight>();
        cardRight.battleRight = true;
        OnlineCardLeft cardLeft = collision.transform.Find("Left").GetComponent<OnlineCardLeft>();
        cardLeft.battleLeft = true;
        Transform canvas = _enemyCardObject.transform.Find("Canvas");
        canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        _myCard.ChangeTag("Enemy");
    }
}
