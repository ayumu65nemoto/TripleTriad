using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;

public class OnlineDropPlace : MonoBehaviourPunCallbacks, IDropHandler, IPunObservable
{
    public enum FieldElement
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

    //カード存在フラグ
    public bool exist = false;
    //ゲームマネージャー取得
    [SerializeField] OnlineGameManager _gameManager;
    //フィールドの属性
    public FieldElement fieldElement;
    //属性アイコンを格納
    [SerializeField] private Sprite[] _fieldIcons;
    [SerializeField] Image iconImage;

    void Start()
    {
        SetElement();
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnlineCardMove card = eventData.pointerDrag.GetComponent<OnlineCardMove>();
        OnlineCard cardStatus = eventData.pointerDrag.GetComponent<OnlineCard>();
        if (card != null && card.setCard == false && exist == false && card.grabCard == true)
        {
            Debug.Log(eventData);
            //カードのパラメータを変更
            ChangeElement(cardStatus);
            //カードの親をフィールドに
            card.transform.SetParent(this.transform);
            //カードの位置を親(フィールド)の０の位置に設定
            card.transform.localPosition = Vector3.zero;
            //カード設置フラグとカード存在フラグを立てる
            card.setCard = true;
            exist = true;
            //ターンを交代する
            photonView.RPC(nameof(ChangeTurn), RpcTarget.All);

            //プレイヤーのカードなら青に、エネミーのカードなら赤に変える
            if (card.tag == "Player")
            {
                Transform canvas = card.transform.Find("Canvas");
                canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(0, 0, 255, 255);
            }
            else if (card.tag == "Enemy")
            {
                Transform canvas = card.transform.Find("Canvas");
                canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            }
        }
    }

    private void SetElement()
    {
        if (Random.Range(0, 2) == 0)
        {
            fieldElement = (FieldElement)Random.Range(0, 9);
        }
        else
        {
            fieldElement = FieldElement.None;
        }
        //属性に応じてアイコンを表示
        if (fieldElement == FieldElement.Fire)
        {
            iconImage.sprite = _fieldIcons[0];
        }
        else if (fieldElement == FieldElement.Thunder)
        {
            iconImage.sprite = _fieldIcons[1];
        }
        else if (fieldElement == FieldElement.Wind)
        {
            iconImage.sprite = _fieldIcons[2];
        }
        else if (fieldElement == FieldElement.Poison)
        {
            iconImage.sprite = _fieldIcons[3];
        }
        else if (fieldElement == FieldElement.Cold)
        {
            iconImage.sprite = _fieldIcons[4];
        }
        else if (fieldElement == FieldElement.Water)
        {
            iconImage.sprite = _fieldIcons[5];
        }
        else if (fieldElement == FieldElement.Earth)
        {
            iconImage.sprite = _fieldIcons[6];
        }
        else if (fieldElement == FieldElement.Holy)
        {
            iconImage.sprite = _fieldIcons[7];
        }
        else if (fieldElement == FieldElement.None)
        {
            iconImage.sprite = _fieldIcons[8];
        }
    }

    private void ChangeElement(OnlineCard card)
    {
        if (fieldElement != FieldElement.None)
        {
            if (card.cardElement != OnlineCard.CardElement.None)
            {
                if (fieldElement.ToString() == card.cardElement.ToString())
                {
                    card.numberTop = card.numberTop + 1;
                    card.numberBottom = card.numberBottom + 1;
                    card.numberRight = card.numberRight + 1;
                    card.numberLeft = card.numberLeft + 1;
                    card.numberTopText.text = card.numberTop.ToString();
                    card.numberBottomText.text = card.numberBottom.ToString();
                    card.numberRightText.text = card.numberRight.ToString();
                    card.numberLeftText.text = card.numberLeft.ToString();
                }
                else
                {
                    card.numberTop = card.numberTop - 1;
                    card.numberBottom = card.numberBottom - 1;
                    card.numberRight = card.numberRight - 1;
                    card.numberLeft = card.numberLeft - 1;
                    card.numberTopText.text = card.numberTop.ToString();
                    card.numberBottomText.text = card.numberBottom.ToString();
                    card.numberRightText.text = card.numberRight.ToString();
                    card.numberLeftText.text = card.numberLeft.ToString();
                }
            }
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //データの送信
            stream.SendNext(fieldElement);
            stream.SendNext(exist);
        }
        else
        {
            //データの受信
            fieldElement = (FieldElement)stream.ReceiveNext();
            exist = (bool)stream.ReceiveNext();

            //属性に応じてアイコンを表示
            if (fieldElement == FieldElement.Fire)
            {
                iconImage.sprite = _fieldIcons[0];
            }
            else if (fieldElement == FieldElement.Thunder)
            {
                iconImage.sprite = _fieldIcons[1];
            }
            else if (fieldElement == FieldElement.Wind)
            {
                iconImage.sprite = _fieldIcons[2];
            }
            else if (fieldElement == FieldElement.Poison)
            {
                iconImage.sprite = _fieldIcons[3];
            }
            else if (fieldElement == FieldElement.Cold)
            {
                iconImage.sprite = _fieldIcons[4];
            }
            else if (fieldElement == FieldElement.Water)
            {
                iconImage.sprite = _fieldIcons[5];
            }
            else if (fieldElement == FieldElement.Earth)
            {
                iconImage.sprite = _fieldIcons[6];
            }
            else if (fieldElement == FieldElement.Holy)
            {
                iconImage.sprite = _fieldIcons[7];
            }
            else if (fieldElement == FieldElement.None)
            {
                iconImage.sprite = _fieldIcons[8];
            }
        }
    }

    [PunRPC]
    void ChangeTurn()
    {
        _gameManager.turn = !_gameManager.turn;
    }
}
