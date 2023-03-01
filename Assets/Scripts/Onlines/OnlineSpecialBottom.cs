using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineSpecialBottom : MonoBehaviour
{
    [SerializeField] private Card _myCard;
    [SerializeField] private GameObject _myCardObject;
    [SerializeField] private OnlineCardMove _cardMove;
    [SerializeField] private OnlineSpecialTop _specialTop;
    [SerializeField] private OnlineSpecialRight _specialRight;
    [SerializeField] private OnlineSpecialLeft _specialLeft;
    public bool sameBottom = false;
    public bool plusFlagBottom = false;
    public int plusBottom;
    private int _plusCount = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_myCardObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameObject _enemyCardObject = collision.gameObject;
                Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                OnlineCardMove _enemyCardMove = _enemyCardObject.GetComponent<OnlineCardMove>();
                if (_enemyCardMove.setCard == true)
                {
                    if (_myCard.numberBottom == _enemyCard.numberTop && _cardMove.setCard == true)
                    {
                        sameBottom = true;
                        Debug.Log("a2");
                        if (sameBottom == true && _specialTop.sameTop == true || sameBottom == true && _specialRight.sameRight == true || sameBottom == true && _specialLeft.sameLeft == true)
                        {
                            _specialTop.SpecialPlayerAction(collision, _enemyCardObject);
                            Debug.Log("b2");
                        }
                        Invoke("ChangeSameFlagLate", 2f);
                    }

                    if (_cardMove.setCard == true && _plusCount > 0)
                    {
                        plusBottom = _myCard.numberBottom + _enemyCard.numberTop;
                        plusFlagBottom = true;
                        Invoke("ChangePlusFlagLate", 2f);
                        _plusCount--;
                        Debug.Log("plusBottomEnter");
                    }

                    if (plusBottom == _specialTop.plusTop || plusBottom == _specialRight.plusRight || plusBottom == _specialLeft.plusLeft)
                    {
                        if (plusFlagBottom == true)
                        {
                            _specialTop.SpecialPlayerAction(collision, _enemyCardObject);
                            plusFlagBottom = false;
                            Debug.Log("plusBottom");
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
                Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                OnlineCardMove _enemyCardMove = _enemyCardObject.GetComponent<OnlineCardMove>();
                if (_enemyCardMove.setCard == true)
                {
                    if (_myCard.numberBottom == _enemyCard.numberTop && _cardMove.setCard == true)
                    {
                        sameBottom = true;
                        if (sameBottom == true && _specialTop.sameTop == true || sameBottom == true && _specialRight.sameRight == true || sameBottom == true && _specialLeft.sameLeft == true)
                        {
                            _specialTop.SpecialEnemyAction(collision, _enemyCardObject);
                            Debug.Log("b2");
                        }
                        Invoke("ChangeSameFlagLate", 2f);
                    }

                    if (_cardMove.setCard == true && _plusCount > 0)
                    {
                        plusBottom = _myCard.numberBottom + _enemyCard.numberTop;
                        plusFlagBottom = true;
                        Invoke("ChangePlusFlagLate", 2f);
                        _plusCount--;
                        Debug.Log("plusBottomEnter2");
                    }

                    if (plusBottom == _specialTop.plusTop || plusBottom == _specialRight.plusRight || plusBottom == _specialLeft.plusLeft)
                    {
                        if (plusFlagBottom == true)
                        {
                            _specialTop.SpecialEnemyAction(collision, _enemyCardObject);
                            plusFlagBottom = false;
                            Debug.Log("plusBottom2");
                        }
                    }
                }
            }
        }
    }

    private void ChangeSameFlagLate()
    {
        sameBottom = false;
    }

    private void ChangePlusFlagLate()
    {
        plusFlagBottom = false;
    }
}
