using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropPlace : MonoBehaviour, IDropHandler
{
    //�J�[�h���݃t���O
    private bool _exist = false;

    public void OnDrop(PointerEventData eventData)
    {
        CardMove card = eventData.pointerDrag.GetComponent<CardMove>();
        if (card != null && card.setCard == false && _exist == false)
        {
            //�J�[�h�̐e���t�B�[���h��
            card.defaultParent = this.transform;
            //�J�[�h�̈ʒu��e(�t�B�[���h)�̂O�̈ʒu�ɐݒ�
            card.transform.localPosition = Vector3.zero;
            //�J�[�h�ݒu�t���O�ƃJ�[�h���݃t���O�𗧂Ă�
            card.setCard = true;
            _exist = true;

            //�v���C���[�̃J�[�h�Ȃ�ɁA�G�l�~�[�̃J�[�h�Ȃ�Ԃɕς���
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
