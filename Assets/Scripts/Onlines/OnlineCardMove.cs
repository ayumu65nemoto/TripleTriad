using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Realtime;

public class OnlineCardMove : MonoBehaviourPunCallbacks, IPunObservable, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //親要素取得
    public Transform defaultParent;
    //手札にある状態の位置を取得
    private Vector3 _currentPosition;
    //カード設置フラグ
    public bool setCard;
    //ゲームマネージャー取得
    [SerializeField] OnlineGameManager _gameManager;
    //PhotonManager取得
    private GameObject _gameObject;
    private PhotonManager _photonManager;
    //カードをつかんでいる
    public bool grabCard;
    //Canvas
    GameObject _canvas;

    private void Start()
    {
        //フラグリセット
        setCard = false;
        grabCard = false;
        //ゲームマネージャー取得
        _gameManager = GameObject.Find("GameManager").GetComponent<OnlineGameManager>();
        //PhotonManager取得
        _gameObject = GameObject.Find("PhotonManager");
        _photonManager = _gameObject.GetComponent<PhotonManager>();
        //Canvas取得
        _canvas = GameObject.FindWithTag("Canvas");
        //親をCanvasに
        this.gameObject.transform.SetParent(_canvas.transform);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //現在位置取得
        _currentPosition = this.transform.position;
        //レイをブロックする機能をオフ
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //親をCanvasに
        this.gameObject.transform.SetParent(_canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_photonManager.playerId == 1)
        {
            if (setCard == false && _gameManager.turn == true && eventData.pointerDrag.tag == "Player")
            {
                //マウス位置に移動
                transform.position = eventData.position;
                grabCard = true;
            }
        }
        if (_photonManager.playerId == 2)
        {
            if (setCard == false && _gameManager.turn == false && eventData.pointerDrag.tag == "Enemy")
            {
                transform.position = eventData.position;
                grabCard = true;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //レイをブロックする機能をオン
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        //カードがセットされなければ
        if (setCard == false)
        {
            //初期位置に戻す
            transform.position = _currentPosition;
            grabCard = false;
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //データの送信
            stream.SendNext(setCard);
        }
        else
        {
            //データの受信
            setCard = (bool)stream.ReceiveNext();
        }
    }
}
