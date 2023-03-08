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

    //�J�[�h���݃t���O
    public bool exist = false;
    //�Q�[���}�l�[�W���[�擾
    [SerializeField] OnlineGameManager _gameManager;
    //�t�B�[���h�̑���
    public FieldElement fieldElement;
    //�����A�C�R�����i�[
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
            //�J�[�h�̃p�����[�^��ύX
            ChangeElement(cardStatus);
            //�J�[�h���t�B�[���h�ɃZ�b�g
            SetCardPosition(card);
            //�^�[������シ��
            photonView.RPC(nameof(ChangeTurn), RpcTarget.All);

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
        //�����ɉ����ăA�C�R����\��
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
            //�f�[�^�̑��M
            stream.SendNext(fieldElement);
            stream.SendNext(exist);
        }
        else
        {
            //�f�[�^�̎�M
            fieldElement = (FieldElement)stream.ReceiveNext();
            exist = (bool)stream.ReceiveNext();

            //�����ɉ����ăA�C�R����\��
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

    private void SetCardPosition(OnlineCardMove card)
    {
        if (this.gameObject.name == "CardPosition")
        {
            //�J�[�h�̈ʒu��ݒ�
            card.transform.localPosition = new Vector3(245, 335);
            //�J�[�h�ݒu�t���O�ƃJ�[�h���݃t���O�𗧂Ă�
            card.setCard = true;
            exist = true;
        }
        if (this.gameObject.name == "CardPosition1")
        {
            //�J�[�h�̈ʒu��e(�t�B�[���h)�̂O�̈ʒu�ɐݒ�
            card.transform.localPosition = new Vector3(245, 0);
            //�J�[�h�ݒu�t���O�ƃJ�[�h���݃t���O�𗧂Ă�
            card.setCard = true;
            exist = true;
        }
        if (this.gameObject.name == "CardPosition2")
        {
            //�J�[�h�̈ʒu��e(�t�B�[���h)�̂O�̈ʒu�ɐݒ�
            card.transform.localPosition = new Vector3(245, -335);
            //�J�[�h�ݒu�t���O�ƃJ�[�h���݃t���O�𗧂Ă�
            card.setCard = true;
            exist = true;
        }
        if (this.gameObject.name == "CardPosition3")
        {
            //�J�[�h�̈ʒu��e(�t�B�[���h)�̂O�̈ʒu�ɐݒ�
            card.transform.localPosition = new Vector3(0, 335);
            //�J�[�h�ݒu�t���O�ƃJ�[�h���݃t���O�𗧂Ă�
            card.setCard = true;
            exist = true;
        }
        if (this.gameObject.name == "CardPosition4")
        {
            //�J�[�h�̈ʒu��e(�t�B�[���h)�̂O�̈ʒu�ɐݒ�
            card.transform.localPosition = new Vector3(0, 0);
            //�J�[�h�ݒu�t���O�ƃJ�[�h���݃t���O�𗧂Ă�
            card.setCard = true;
            exist = true;
        }
        if (this.gameObject.name == "CardPosition5")
        {
            //�J�[�h�̈ʒu��e(�t�B�[���h)�̂O�̈ʒu�ɐݒ�
            card.transform.localPosition = new Vector3(0, -335);
            //�J�[�h�ݒu�t���O�ƃJ�[�h���݃t���O�𗧂Ă�
            card.setCard = true;
            exist = true;
        }
        if (this.gameObject.name == "CardPosition6")
        {
            //�J�[�h�̈ʒu��e(�t�B�[���h)�̂O�̈ʒu�ɐݒ�
            card.transform.localPosition = new Vector3(-245, 335);
            //�J�[�h�ݒu�t���O�ƃJ�[�h���݃t���O�𗧂Ă�
            card.setCard = true;
            exist = true;
        }
        if (this.gameObject.name == "CardPosition7")
        {
            //�J�[�h�̈ʒu��e(�t�B�[���h)�̂O�̈ʒu�ɐݒ�
            card.transform.localPosition = new Vector3(-245, 0);
            //�J�[�h�ݒu�t���O�ƃJ�[�h���݃t���O�𗧂Ă�
            card.setCard = true;
            exist = true;
        }
        if (this.gameObject.name == "CardPosition8")
        {
            //�J�[�h�̈ʒu��e(�t�B�[���h)�̂O�̈ʒu�ɐݒ�
            card.transform.localPosition = new Vector3(-245, -335);
            //�J�[�h�ݒu�t���O�ƃJ�[�h���݃t���O�𗧂Ă�
            card.setCard = true;
            exist = true;
        }
    }

    [PunRPC]
    void ChangeTurn()
    {
        _gameManager.turn = !_gameManager.turn;
    }
}
