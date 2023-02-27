using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropPlace : MonoBehaviour, IDropHandler
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
    public bool playerExist = false;
    //ゲームマネージャー取得
    [SerializeField] GameManager _gameManager;
    //フィールドの属性
    public FieldElement fieldElement;
    //属性アイコンを格納
    [SerializeField] private Sprite[] _fieldIcons;
    [SerializeField] Image iconImage;

    void Start()
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

    public void OnDrop(PointerEventData eventData)
    {
        CardMove card = eventData.pointerDrag.GetComponent<CardMove>();
        Card cardStatus = eventData.pointerDrag.GetComponent<Card>();
        if (card != null && card.setCard == false && exist == false && _gameManager.turn == true /*&& card.tag == "Player"*/)
        {
            //カードのパラメータを変更
            ChangeElement(cardStatus);
            //カードの親をフィールドに
            card.defaultParent = this.transform;
            //カードの位置を親(フィールド)の０の位置に設定
            card.transform.localPosition = Vector3.zero;
            //カード設置フラグとカード存在フラグを立てる
            card.setCard = true;
            exist = true;
            //ターンを交代する
            _gameManager.turn = !_gameManager.turn;

            //プレイヤーのカードなら青に、エネミーのカードなら赤に変える
            if (card.tag == "Player")
            {
                Transform canvas = card.transform.Find("Canvas");
                canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(0, 0, 255, 255);
                playerExist = true;
            }
            else if (card.tag == "Enemy")
            {
                Transform canvas = card.transform.Find("Canvas");
                canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            }
        }
    }

    private void ChangeElement(Card card)
    {
        if (fieldElement != FieldElement.None)
        {
            if (card.cardElement != Card.CardElement.None)
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
}
