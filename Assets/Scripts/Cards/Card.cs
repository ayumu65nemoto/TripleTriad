using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    //�J�[�h�̑���
    public enum CardElement
    {
        None,
        Fire,
        Thunder,
        Wind,
        Poison,
        Cold,
        Water,
        Earth,
        Holy
    }

    //�����A�C�R�����i�[
    [SerializeField] private Sprite[] _icons;

    [SerializeField] public int numberTop;
    [SerializeField] public int numberBottom;
    [SerializeField] public int numberRight;
    [SerializeField] public int numberLeft;
    [SerializeField] public Sprite icon;
    public CardElement cardElement;

    [SerializeField] Text numberTopText;
    [SerializeField] Text numberBottomText;
    [SerializeField] Text numberRightText;
    [SerializeField] Text numberLeftText;
    [SerializeField] Image iconImage;

    //�֐���o�^�ł���
    public UnityAction<Card> OnSelectCard;

    public void Set()
    {
        //�J�[�h�p���[�������_���ɐݒ�
        numberTop = Random.Range(1, 11);
        numberBottom = Random.Range(1, 11);
        numberRight = Random.Range(1, 11);
        numberLeft = Random.Range(1, 11);
        //�J�[�h�̑����������_���Ɍ���
        cardElement = (CardElement)Random.Range(0, 9);

        //�J�[�h�̃p���[��\��
        numberTopText.text = numberTop.ToString();
        numberBottomText.text = numberBottom.ToString();
        numberRightText.text = numberRight.ToString();
        numberLeftText.text = numberLeft.ToString();
        //�����ɉ����ăA�C�R����\��
        if (cardElement == CardElement.Fire)
        {
            iconImage.sprite = _icons[0];
        }
        else if (cardElement == CardElement.Thunder)
        {
            iconImage.sprite = _icons[1];
        }
        else if (cardElement == CardElement.Wind)
        {
            iconImage.sprite = _icons[2];
        }
        else if (cardElement == CardElement.Poison)
        {
            iconImage.sprite = _icons[3];
        }
        else if (cardElement == CardElement.Cold)
        {
            iconImage.sprite = _icons[4];
        }
        else if (cardElement == CardElement.Water)
        {
            iconImage.sprite = _icons[5];
        }
        else if (cardElement == CardElement.Earth)
        {
            iconImage.sprite = _icons[6];
        }
        else if (cardElement == CardElement.Holy)
        {
            iconImage.sprite = _icons[7];
        }
        else if (cardElement == CardElement.None)
        {
            iconImage.sprite = _icons[8];
        }
    }
}
