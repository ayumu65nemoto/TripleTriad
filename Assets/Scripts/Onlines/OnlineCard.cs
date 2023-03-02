using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class OnlineCard : MonoBehaviourPunCallbacks, IPunObservable
{
    //カードの属性
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

    //属性アイコンを格納
    [SerializeField] private Sprite[] _icons;

    [SerializeField] public int numberTop;
    [SerializeField] public int numberBottom;
    [SerializeField] public int numberRight;
    [SerializeField] public int numberLeft;
    [SerializeField] public Sprite icon;
    public CardElement cardElement;

    [SerializeField] public Text numberTopText;
    [SerializeField] public Text numberBottomText;
    [SerializeField] public Text numberRightText;
    [SerializeField] public Text numberLeftText;
    [SerializeField] Image iconImage;

    public void Set()
    {
        //カードパワーをランダムに設定
        numberTop = Random.Range(1, 11);
        numberBottom = Random.Range(1, 11);
        numberRight = Random.Range(1, 11);
        numberLeft = Random.Range(1, 11);
        //カードの属性をランダムに決定
        cardElement = (CardElement)Random.Range(0, 9);

        //カードのパワーを表示
        numberTopText.text = numberTop.ToString();
        numberBottomText.text = numberBottom.ToString();
        numberRightText.text = numberRight.ToString();
        numberLeftText.text = numberLeft.ToString();
        //属性に応じてアイコンを表示
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

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //データの送信
            stream.SendNext(numberTop);
            stream.SendNext(numberBottom);
            stream.SendNext(numberRight);
            stream.SendNext(numberLeft);
            stream.SendNext(numberTopText.text);
            stream.SendNext(numberBottomText.text);
            stream.SendNext(numberRightText.text);
            stream.SendNext(numberLeftText.text);
            stream.SendNext(cardElement);
        }
        else
        {
            //データの受信
            numberTop = (int)stream.ReceiveNext();
            numberBottom = (int)stream.ReceiveNext();
            numberRight = (int)stream.ReceiveNext();
            numberLeft = (int)stream.ReceiveNext();
            numberTopText.text = (string)stream.ReceiveNext();
            numberBottomText.text = (string)stream.ReceiveNext();
            numberRightText.text = (string)stream.ReceiveNext();
            numberLeftText.text = (string)stream.ReceiveNext();
            cardElement = (CardElement)stream.ReceiveNext();
        }
    }
}
