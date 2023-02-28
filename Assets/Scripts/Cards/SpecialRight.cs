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
    public bool plusFlagRight = false;
    public int plusRight;
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
                    if (_myCard.numberRight == _enemyCard.numberLeft && _cardMove.setCard == true)
                    {
                        sameRight = true;
                        if (sameRight == true && _specialTop.sameTop == true || sameRight == true && _specialBottom.sameBottom == true || sameRight == true && _specialLeft.sameLeft == true)
                        {
                            _specialTop.SpecialPlayerAction(collision, _enemyCardObject);
                            Debug.Log("b3");
                        }
                        Invoke("ChangeSameFlagLate", 2f);
                    }

                    if (_cardMove.setCard == true && _plusCount > 0)
                    {
                        plusRight = _myCard.numberRight + _enemyCard.numberLeft;
                        plusFlagRight = true;
                        Invoke("ChangePlusFlagLate", 2f);
                        _plusCount--;
                        Debug.Log("plusRightEnter");
                    }

                    if (plusRight == _specialTop.plusTop || plusRight == _specialBottom.plusBottom || plusRight == _specialLeft.plusLeft)
                    {
                        if (plusFlagRight == true)
                        {
                            _specialTop.SpecialPlayerAction(collision, _enemyCardObject);
                            plusFlagRight = false;
                            Debug.Log("plusRight");
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
                    if (_myCard.numberRight == _enemyCard.numberLeft && _cardMove.setCard == true)
                    {
                        sameRight = true;
                        if (sameRight == true && _specialTop.sameTop == true || sameRight == true && _specialBottom.sameBottom == true || sameRight == true && _specialLeft.sameLeft == true)
                        {
                            _specialTop.SpecialEnemyAction(collision, _enemyCardObject);
                            Debug.Log("b3");
                        }
                        Invoke("ChangeSameFlagLate", 2f);
                    }

                    if (_cardMove.setCard == true && _plusCount > 0)
                    {
                        plusRight = _myCard.numberRight + _enemyCard.numberLeft;
                        plusFlagRight = true;
                        Invoke("ChangePlusFlagLate", 2f);
                        _plusCount--;
                        Debug.Log("plusRightEnter2");
                    }

                    if (plusRight == _specialTop.plusTop || plusRight == _specialBottom.plusBottom || plusRight == _specialLeft.plusLeft)
                    {
                        if (plusFlagRight == true)
                        {
                            _specialTop.SpecialEnemyAction(collision, _enemyCardObject);
                            plusFlagRight = false;
                            Debug.Log("plusRight2");
                        }
                    }
                }
            }
        }
    }

    private void ChangeSameFlagLate()
    {
        sameRight = false;
    }

    private void ChangePlusFlagLate()
    {
        plusFlagRight = false;
    }
}
