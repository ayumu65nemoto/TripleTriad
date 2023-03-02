using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineSpecialLeft : MonoBehaviour
{
    [SerializeField] private OnlineCard _myCard;
    [SerializeField] private GameObject _myCardObject;
    [SerializeField] private OnlineCardMove _cardMove;
    [SerializeField] private OnlineSpecialTop _specialTop;
    [SerializeField] private OnlineSpecialBottom _specialBottom;
    [SerializeField] private OnlineSpecialRight _specialRight;
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
                OnlineCard _enemyCard = _enemyCardObject.GetComponent<OnlineCard>();
                OnlineCardMove _enemyCardMove = _enemyCardObject.GetComponent<OnlineCardMove>();
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
                OnlineCard _enemyCard = _enemyCardObject.GetComponent<OnlineCard>();
                OnlineCardMove _enemyCardMove = _enemyCardObject.GetComponent<OnlineCardMove>();
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
