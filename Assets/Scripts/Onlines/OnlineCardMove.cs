using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnlineCardMove : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //�e�v�f�擾
    public Transform defaultParent;
    //��D�ɂ����Ԃ̈ʒu���擾
    private Vector3 _currentPosition;
    //�J�[�h�ݒu�t���O
    public bool setCard;
    //�Q�[���}�l�[�W���[�擾
    [SerializeField] OnlineGameManager _gameManager;
    //PhotonManager�擾
    private GameObject _gameObject;
    private PhotonManager _photonManager;
    //�J�[�h������ł���
    public bool grabCard;

    private void Start()
    {
        //���݈ʒu�擾
        _currentPosition = this.transform.position;
        //�t���O���Z�b�g
        setCard = false;
        grabCard = false;
        //�Q�[���}�l�[�W���[�擾
        _gameManager = GameObject.Find("GameManager").GetComponent<OnlineGameManager>();
        //PhotonManager�擾
        _gameObject = GameObject.Find("PhotonManager");
        _photonManager = _gameObject.GetComponent<PhotonManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //�e�v�f�擾
        defaultParent = transform.parent;
        //���C���u���b�N����@�\���I�t
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (_photonManager.playerId == 1)
        {
            if (setCard == false && _gameManager.turn == true && eventData.pointerDrag.tag == "Player")
            {
                //�e�̐e�v�f��e�v�f�ɂ���
                transform.SetParent(defaultParent.parent, false);
            }
        }
        if (_photonManager.playerId == 2)
        {
            if (setCard == false && _gameManager.turn == false && eventData.pointerDrag.tag == "Enemy")
            {
                //�e�̐e�v�f��e�v�f�ɂ���
                transform.SetParent(defaultParent.parent, false);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_photonManager.playerId == 1)
        {
            if (setCard == false && _gameManager.turn == true && eventData.pointerDrag.tag == "Player")
            {
                //�}�E�X�ʒu�Ɉړ�
                transform.position = eventData.position;
                grabCard = true;
            }
        }
        if (_photonManager.playerId == 2)
        {
            if (setCard == false && _gameManager.turn == false && eventData.pointerDrag.tag == "Enemy")
            {
                //�}�E�X�ʒu�Ɉړ�
                transform.position = eventData.position;
                grabCard = true;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //���Ƃ̐e�v�f�ɖ߂�
        transform.SetParent(defaultParent, false);
        //���C���u���b�N����@�\���I��
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        //�J�[�h���Z�b�g����Ȃ����
        if (setCard == false)
        {
            //�����ʒu�ɖ߂�
            transform.position = _currentPosition;
            grabCard = false;
        }
    }
}
