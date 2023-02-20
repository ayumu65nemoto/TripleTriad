using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropPlace : MonoBehaviour, IDropHandler
{
    //�J�[�h���݃t���O
    public bool exist = false;
    public bool playerExist = false;
    //�Q�[���}�l�[�W���[�擾
    [SerializeField] GameManager _gameManager;
    ////�ŏ��̃^�[�����L��
    //private bool _firstTurn;

    //void Start()
    //{
    //    _firstTurn = _gameManager.turn;
    //}

    //void Update()
    //{
    //    if (exist == true)
    //    {
    //        if (_firstTurn != _gameManager.turn)
    //        {
    //            GameObject card = transform.GetChild(0).gameObject;
    //            CardTop cardTop = card.transform.GetChild(1).gameObject.GetComponent<CardTop>();
    //            CardBottom cardBottom = card.transform.GetChild(2).gameObject.GetComponent<CardBottom>();
    //            CardRight cardRight = card.transform.GetChild(3).gameObject.GetComponent<CardRight>();
    //            CardLeft cardLeft = card.transform.GetChild(4).gameObject.GetComponent<CardLeft>();
    //            cardTop.battleTop = false;
    //            cardBottom.battleBottom = false;
    //            cardRight.battleRight = false;
    //            cardLeft.battleLeft = false;
    //            Debug.Log(cardLeft.battleLeft);
    //            _firstTurn = _gameManager.turn;
    //        }
    //    }
    //}

    public void OnDrop(PointerEventData eventData)
    {
        CardMove card = eventData.pointerDrag.GetComponent<CardMove>();
        if (card != null && card.setCard == false && exist == false && _gameManager.turn == true)
        {
            //�J�[�h�̐e���t�B�[���h��
            card.defaultParent = this.transform;
            //�J�[�h�̈ʒu��e(�t�B�[���h)�̂O�̈ʒu�ɐݒ�
            card.transform.localPosition = Vector3.zero;
            //�J�[�h�ݒu�t���O�ƃJ�[�h���݃t���O�𗧂Ă�
            card.setCard = true;
            exist = true;
            //�^�[������シ��
            _gameManager.turn = !_gameManager.turn;

            //�v���C���[�̃J�[�h�Ȃ�ɁA�G�l�~�[�̃J�[�h�Ȃ�Ԃɕς���
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
}
