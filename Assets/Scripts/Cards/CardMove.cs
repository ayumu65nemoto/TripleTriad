using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMove : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //�e�v�f�擾
    public Transform defaultParent;
    //��D�ɂ����Ԃ̈ʒu���擾
    private Vector3 _currentPosition;
    //�J�[�h�ݒu�t���O
    public bool setCard;

    private void Start()
    {
        //���݈ʒu�擾
        _currentPosition = this.transform.position;
        //�t���O���Z�b�g
        setCard = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //�e�v�f�擾
        defaultParent = transform.parent;
        //���C���u���b�N����@�\���I�t
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (setCard == false)
        {
            //�e�̐e�v�f��e�v�f�ɂ���
            transform.SetParent(defaultParent.parent, false);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (setCard == false)
        {
            //�}�E�X�ʒu�Ɉړ�
            transform.position = eventData.position;
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
        }
    }
}
