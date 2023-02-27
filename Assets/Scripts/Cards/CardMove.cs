using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMove : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //親要素取得
    public Transform defaultParent;
    //手札にある状態の位置を取得
    private Vector3 _currentPosition;
    //カード設置フラグ
    public bool setCard;
    //ゲームマネージャー取得
    [SerializeField] GameManager _gameManager;

    private void Start()
    {
        //現在位置取得
        _currentPosition = this.transform.position;
        //フラグリセット
        setCard = false;
        //ゲームマネージャー取得
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //親要素取得
        defaultParent = transform.parent;
        //レイをブロックする機能をオフ
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (setCard == false && _gameManager.turn == true/* && gameObject.tag == "Player"*/)
        {
            //親の親要素を親要素にする
            transform.SetParent(defaultParent.parent, false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (setCard == false && _gameManager.turn == true/* && gameObject.tag == "Player"*/)
        {
            //マウス位置に移動
            transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //もとの親要素に戻す
        transform.SetParent(defaultParent, false);
        //レイをブロックする機能をオン
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        //カードがセットされなければ
        if (setCard == false)
        {
            //初期位置に戻す
            transform.position = _currentPosition;
        }
    }
}
