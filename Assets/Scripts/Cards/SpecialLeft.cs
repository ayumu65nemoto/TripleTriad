using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialLeft : MonoBehaviour
{
    [SerializeField] private Card _myCard;
    [SerializeField] private GameObject _myCardObject;
    [SerializeField] private CardMove _cardMove;
    [SerializeField] private SpecialTop _specialTop;
    [SerializeField] private SpecialBottom _specialBottom;
    [SerializeField] private SpecialRight _specialRight;
    public bool sameLeft = false;
    public bool plusFlagLeft = false;
    public int plusLeft;
    private int _plusCount = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_myCardObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameObject _enemyCardObject = collision.gameObject;
                Card _enemyCard = _enemyCardObject.GetComponent<Card>();
                CardMove _enemyCardMove = _enemyCardObject.GetComponent<CardMove>();
                if (_enemyCardMove.setCard == true)
                {
                    if (_myCard.numberLeft == _enemyCard.numberRight && _cardMove.setCard == true)
                    {
                        sameLeft = true;
                        if (sameLeft == true && _specialTop.sameTop == true || sameLeft == true && _specialRight.sameRight == true || sameLeft == true && _specialBottom.sameBottom == true)
                        {
                            _specialTop.SpecialPlayerAction(collision, _enemyCardObject);
                            Debug.Log("b4");
                        }
                        Invoke("ChangeSameFlagLate", 2f);
                    }

                    if (_cardMove.setCard == true && _plusCount > 0)
                    {
                        plusLeft = _myCard.numberLeft + _enemyCard.numberRight;
                        plusFlagLeft = true;
                        Invoke("ChangePlusFlagLate", 2f);
                        _plusCount--;
                        Debug.Log("plusLeftEnter");
                    }

                    if (plusLeft == _specialTop.plusTop || plusLeft == _specialBottom.plusBottom || plusLeft == _specialRight.plusRight)
                    {
                        if (plusFlagLeft == true)
                        {
                            _specialTop.SpecialPlayerAction(collision, _enemyCardObject);
                            plusFlagLeft = false;
                            Debug.Log("plusLeft");
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
                CardMove _enemyCardMove = _enemyCardObject.GetComponent<CardMove>();
                if (_enemyCardMove.setCard == true)
                {
                    if (_myCard.numberLeft == _enemyCard.numberRight && _cardMove.setCard == true)
                    {
                        sameLeft = true;
                        if (sameLeft == true && _specialTop.sameTop == true || sameLeft == true && _specialRight.sameRight == true || sameLeft == true && _specialBottom.sameBottom == true)
                        {
                            _specialTop.SpecialEnemyAction(collision, _enemyCardObject);
                            Debug.Log("b4");
                        }
                        Invoke("ChangeSameFlagLate", 2f);
                    }

                    if (_cardMove.setCard == true && _plusCount > 0)
                    {
                        plusLeft = _myCard.numberLeft + _enemyCard.numberRight;
                        plusFlagLeft = true;
                        Invoke("ChangePlusFlagLate", 2f);
                        _plusCount--;
                        Debug.Log("plusLeftEnter2");
                    }

                    if (plusLeft == _specialTop.plusTop || plusLeft == _specialBottom.plusBottom || plusLeft == _specialRight.plusRight)
                    {
                        if (plusFlagLeft == true)
                        {
                            _specialTop.SpecialEnemyAction(collision, _enemyCardObject);
                            plusFlagLeft = false;
                            Debug.Log("plusLeft2");
                        }
                    }
                }
            }
        }
    }

    private void ChangeSameFlagLate()
    {
        sameLeft = false;
    }

    private void ChangePlusFlagLate()
    {
        plusFlagLeft = false;
    }
}
