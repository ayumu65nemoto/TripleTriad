using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropPlace : MonoBehaviour, IDropHandler
{
    //カード存在フラグ
    private bool _exist = false;

    public void OnDrop(PointerEventData eventData)
    {
        CardMove card = eventData.pointerDrag.GetComponent<CardMove>();
        if (card != null && card.setCard == false && _exist == false)
        {
            //カードの親をフィールドに
            card.defaultParent = this.transform;
            //カードの位置を親(フィールド)の０の位置に設定
            card.transform.localPosition = Vector3.zero;
            //カード設置フラグとカード存在フラグを立てる
            card.setCard = true;
            _exist = true;

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
}
