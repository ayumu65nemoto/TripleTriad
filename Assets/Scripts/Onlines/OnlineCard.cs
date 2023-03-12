using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class OnlineCard : MonoBehaviourPunCallbacks, IPunObservable
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

    [SerializeField] public Text numberTopText;
    [SerializeField] public Text numberBottomText;
    [SerializeField] public Text numberRightText;
    [SerializeField] public Text numberLeftText;
    [SerializeField] Image iconImage;

    public string cardTag; // �J�[�h�̃^�O

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

    // �J�[�h�̃^�O���ύX���ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    public void ChangeTag(string newTag)
    {
        cardTag = newTag;

        if (photonView.IsMine)
        {
            // �������g�̃J�[�h�̃^�O���ύX���ꂽ�ꍇ�A���̃v���C���[�ɒʒm����
            photonView.RPC("SyncTag", RpcTarget.Others, cardTag);
        }
    }

    // �J�[�h�̃^�O�𓯊����邽�߂�RPC���\�b�h
    [PunRPC]
    private void SyncTag(string newTag)
    {
        cardTag = newTag;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //�f�[�^�̑��M
            stream.SendNext(numberTop);
            stream.SendNext(numberBottom);
            stream.SendNext(numberRight);
            stream.SendNext(numberLeft);
            stream.SendNext(numberTopText.text);
            stream.SendNext(numberBottomText.text);
            stream.SendNext(numberRightText.text);
            stream.SendNext(numberLeftText.text);
            stream.SendNext(cardElement);
            stream.SendNext(cardTag);
        }
        else
        {
            //�f�[�^�̎�M
            numberTop = (int)stream.ReceiveNext();
            numberBottom = (int)stream.ReceiveNext();
            numberRight = (int)stream.ReceiveNext();
            numberLeft = (int)stream.ReceiveNext();
            numberTopText.text = (string)stream.ReceiveNext();
            numberBottomText.text = (string)stream.ReceiveNext();
            numberRightText.text = (string)stream.ReceiveNext();
            numberLeftText.text = (string)stream.ReceiveNext();
            cardElement = (CardElement)stream.ReceiveNext();
            cardTag = (string)stream.ReceiveNext();

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
}
