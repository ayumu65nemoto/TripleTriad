using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject _enemyHandField;
    [SerializeField] GameObject _cardPosition;
    [SerializeField] GameObject _cardPosition1;
    [SerializeField] GameObject _cardPosition2;
    [SerializeField] GameObject _cardPosition3;
    [SerializeField] GameObject _cardPosition4;
    [SerializeField] GameObject _cardPosition5;
    [SerializeField] GameObject _cardPosition6;
    [SerializeField] GameObject _cardPosition7;
    [SerializeField] GameObject _cardPosition8;

    //�ϐ��i�[�p
    [SerializeField] private GameObject[] _cards;

    //for������t���O
    private bool _setFlag;
    //EnemyCardSet���P�^�[���ɉ��x���Ă΂�Ă��܂��̂�h��
    private bool _once = true;
    //�������X���[�t���O
    private bool _pos = true;
    private bool _pos1 = true;
    private bool _pos2 = true;
    private bool _pos3 = true;
    private bool _pos4 = true;
    private bool _pos5 = true;
    private bool _pos6 = true;
    private bool _pos7 = true;
    private bool _pos8 = true;
    private bool _posStart = true;

    //�J�[�h��u���ʒu
    private Vector3 _card = new Vector3(90, 120, 0);
    private Vector3 _card1 = new Vector3(90, 0, 0);
    private Vector3 _card2 = new Vector3(90, -120, 0);
    private Vector3 _card3 = new Vector3(0, 120, 0);
    private Vector3 _card4 = new Vector3(0, 0, 0);
    private Vector3 _card5 = new Vector3(0, -120, 0);
    private Vector3 _card6 = new Vector3(-90, 120, 0);
    private Vector3 _card7 = new Vector3(-90, 0, 0);
    private Vector3 _card8 = new Vector3(-90, -120, 0);
    private Vector3[] _cardsPos = { new Vector3(90, 120, 0), new Vector3(90, 0, 0), new Vector3(90, -120, 0), 
                                    new Vector3(0, 120, 0), new Vector3(0, 0, 0), new Vector3(0, -120, 0),
                                    new Vector3(-90, 120, 0), new Vector3(-90, 0, 0), new Vector3(-90, -120, 0) };

    private void Update()
    {
        if (_gameManager.turn == false && _gameManager.gameSet == false)
        {
            if (_once == true)
            {
                Invoke("EnemyCardSet", 1.0f);
                _once = false;
            }
        }
    }

    void EnemyCardSet()
    {
        if (_cardPosition.GetComponent<DropPlace>().playerExist == true && _pos == true)
        {
            _setFlag = true;
            for (int i = 0; i < _enemyHandField.transform.childCount; i++)
            {
                Card card = _cardPosition.transform.GetChild(1).gameObject.GetComponent<Card>();
                _cards[i] = _enemyHandField.transform.GetChild(i).gameObject;
                if (_cards[i].GetComponent<Card>().numberRight > card.numberLeft && _cardPosition3.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition3.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition3, _cardsPos[3]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberTop > card.numberBottom && _cardPosition1.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition1.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition1, _cardsPos[1]);
                    _setFlag = false;
                }
            }
            int rand = Random.Range(0, _enemyHandField.transform.childCount);
            _cards[rand] = _enemyHandField.transform.GetChild(rand).gameObject;
            GameObject[] positions = { _cardPosition, _cardPosition1, _cardPosition2, _cardPosition3, _cardPosition4, _cardPosition5, _cardPosition6, _cardPosition7, _cardPosition8 };
            while (_setFlag == true)
            {
                int randam = Random.Range(0, positions.Length);
                GameObject selectPosition = positions[randam];
                DropPlace dropPlace = selectPosition.GetComponent<DropPlace>();
                if (dropPlace.exist == false)
                {
                    dropPlace.exist = true;
                    EnemySetCard(_cards[rand], selectPosition, _cardsPos[randam]);
                    _setFlag = false;
                    Debug.Log("count");
                }
            }
            _pos = false;
        }
        else if (_cardPosition1.GetComponent<DropPlace>().playerExist == true && _pos1 == true)
        {
            _setFlag = true;
            for (int i = 0; i < _enemyHandField.transform.childCount; i++)
            {
                Card card = _cardPosition1.transform.GetChild(1).gameObject.GetComponent<Card>();
                _cards[i] = _enemyHandField.transform.GetChild(i).gameObject;
                if (_cards[i].GetComponent<Card>().numberRight > card.numberLeft && _cardPosition4.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition4.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition4, _cardsPos[4]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberTop > card.numberBottom && _cardPosition2.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition2.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition2, _cardsPos[2]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberBottom > card.numberTop && _cardPosition.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition, _cardsPos[0]);
                    _setFlag = false;
                }
            }
            int rand = Random.Range(0, _enemyHandField.transform.childCount);
            _cards[rand] = _enemyHandField.transform.GetChild(rand).gameObject;
            GameObject[] positions = { _cardPosition, _cardPosition1, _cardPosition2, _cardPosition3, _cardPosition4, _cardPosition5, _cardPosition6, _cardPosition7, _cardPosition8 };
            while (_setFlag == true)
            {
                int randam = Random.Range(0, positions.Length);
                GameObject selectPosition = positions[randam];
                DropPlace dropPlace = selectPosition.GetComponent<DropPlace>();
                if (dropPlace.exist == false)
                {
                    dropPlace.exist = true;
                    EnemySetCard(_cards[rand], selectPosition, _cardsPos[randam]);
                    _setFlag = false;
                    Debug.Log("count");
                }
            }
            _pos1 = false;
        }
        else if (_cardPosition2.GetComponent<DropPlace>().playerExist == true && _pos2 == true)
        {
            _setFlag = true;
            for (int i = 0; i < _enemyHandField.transform.childCount; i++)
            {
                Card card = _cardPosition2.transform.GetChild(1).gameObject.GetComponent<Card>();
                _cards[i] = _enemyHandField.transform.GetChild(i).gameObject;
                if (_cards[i].GetComponent<Card>().numberRight > card.numberLeft && _cardPosition5.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition5.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition5, _cardsPos[5]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberBottom > card.numberTop && _cardPosition1.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition1.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition1, _cardsPos[1]);
                    _setFlag = false;
                }
            }
            int rand = Random.Range(0, _enemyHandField.transform.childCount);
            _cards[rand] = _enemyHandField.transform.GetChild(rand).gameObject;
            GameObject[] positions = { _cardPosition, _cardPosition1, _cardPosition2, _cardPosition3, _cardPosition4, _cardPosition5, _cardPosition6, _cardPosition7, _cardPosition8 };
            while (_setFlag == true)
            {
                int randam = Random.Range(0, positions.Length);
                GameObject selectPosition = positions[randam];
                DropPlace dropPlace = selectPosition.GetComponent<DropPlace>();
                if (dropPlace.exist == false)
                {
                    dropPlace.exist = true;
                    EnemySetCard(_cards[rand], selectPosition, _cardsPos[randam]);
                    _setFlag = false;
                    Debug.Log("count");
                }
            }
            _pos2 = false;
        }
        else if (_cardPosition3.GetComponent<DropPlace>().playerExist == true && _pos3 == true)
        {
            _setFlag = true;
            for (int i = 0; i < _enemyHandField.transform.childCount; i++)
            {
                Card card = _cardPosition3.transform.GetChild(1).gameObject.GetComponent<Card>();
                _cards[i] = _enemyHandField.transform.GetChild(i).gameObject;
                if (_cards[i].GetComponent<Card>().numberRight > card.numberLeft && _cardPosition6.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition6.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition6, _cardsPos[6]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberTop > card.numberBottom && _cardPosition4.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition4.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition4, _cardsPos[4]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberLeft > card.numberRight && _cardPosition.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition, _cardsPos[0]);
                    _setFlag = false;
                }
            }
            int rand = Random.Range(0, _enemyHandField.transform.childCount);
            _cards[rand] = _enemyHandField.transform.GetChild(rand).gameObject;
            GameObject[] positions = { _cardPosition, _cardPosition1, _cardPosition2, _cardPosition3, _cardPosition4, _cardPosition5, _cardPosition6, _cardPosition7, _cardPosition8 };
            while (_setFlag == true)
            {
                int randam = Random.Range(0, positions.Length);
                GameObject selectPosition = positions[randam];
                DropPlace dropPlace = selectPosition.GetComponent<DropPlace>();
                if (dropPlace.exist == false)
                {
                    dropPlace.exist = true;
                    EnemySetCard(_cards[rand], selectPosition, _cardsPos[randam]);
                    _setFlag = false;
                    Debug.Log("count");
                }
            }
            _pos3 = false;
        }
        else if (_cardPosition4.GetComponent<DropPlace>().playerExist == true && _pos4 == true)
        {
            _setFlag = true;
            for (int i = 0; i < _enemyHandField.transform.childCount; i++)
            {
                Card card = _cardPosition4.transform.GetChild(1).gameObject.GetComponent<Card>();
                _cards[i] = _enemyHandField.transform.GetChild(i).gameObject;
                if (_cards[i].GetComponent<Card>().numberRight > card.numberLeft && _cardPosition7.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition7.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition7, _cardsPos[7]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberTop > card.numberBottom && _cardPosition5.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition5.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition5, _cardsPos[5]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberBottom > card.numberTop && _cardPosition3.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition3.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition3, _cardsPos[3]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberLeft > card.numberRight && _cardPosition1.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition1.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition1, _cardsPos[1]);
                    _setFlag = false;
                }
            }
            int rand = Random.Range(0, _enemyHandField.transform.childCount);
            _cards[rand] = _enemyHandField.transform.GetChild(rand).gameObject;
            GameObject[] positions = { _cardPosition, _cardPosition1, _cardPosition2, _cardPosition3, _cardPosition4, _cardPosition5, _cardPosition6, _cardPosition7, _cardPosition8 };
            while (_setFlag == true)
            {
                int randam = Random.Range(0, positions.Length);
                GameObject selectPosition = positions[randam];
                DropPlace dropPlace = selectPosition.GetComponent<DropPlace>();
                if (dropPlace.exist == false)
                {
                    dropPlace.exist = true;
                    EnemySetCard(_cards[rand], selectPosition, _cardsPos[randam]);
                    _setFlag = false;
                    Debug.Log("count");
                }
            }
            _pos4 = false;
        }
        else if (_cardPosition5.GetComponent<DropPlace>().playerExist == true && _pos5 == true)
        {
            _setFlag = true;
            for (int i = 0; i < _enemyHandField.transform.childCount; i++)
            {
                Card card = _cardPosition5.transform.GetChild(1).gameObject.GetComponent<Card>();
                _cards[i] = _enemyHandField.transform.GetChild(i).gameObject;
                if (_cards[i].GetComponent<Card>().numberRight > card.numberLeft && _cardPosition8.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition8.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition8, _cardsPos[8]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberBottom > card.numberTop && _cardPosition4.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition4.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition4, _cardsPos[4]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberLeft > card.numberRight && _cardPosition2.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition2.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition2, _cardsPos[2]);
                    _setFlag = false;
                }
            }
            int rand = Random.Range(0, _enemyHandField.transform.childCount);
            _cards[rand] = _enemyHandField.transform.GetChild(rand).gameObject;
            GameObject[] positions = { _cardPosition, _cardPosition1, _cardPosition2, _cardPosition3, _cardPosition4, _cardPosition5, _cardPosition6, _cardPosition7, _cardPosition8 };
            while (_setFlag == true)
            {
                int randam = Random.Range(0, positions.Length);
                GameObject selectPosition = positions[randam];
                DropPlace dropPlace = selectPosition.GetComponent<DropPlace>();
                if (dropPlace.exist == false)
                {
                    dropPlace.exist = true;
                    EnemySetCard(_cards[rand], selectPosition, _cardsPos[randam]);
                    _setFlag = false;
                    Debug.Log("count");
                }
            }
            _pos5 = false;
        }
        else if (_cardPosition6.GetComponent<DropPlace>().playerExist == true && _pos6 == true)
        {
            _setFlag = true;
            for (int i = 0; i < _enemyHandField.transform.childCount; i++)
            {
                Card card = _cardPosition6.transform.GetChild(1).gameObject.GetComponent<Card>();
                _cards[i] = _enemyHandField.transform.GetChild(i).gameObject;
                if (_cards[i].GetComponent<Card>().numberTop > card.numberBottom && _cardPosition7.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition7.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition7, _cardsPos[7]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberLeft > card.numberRight && _cardPosition3.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition3.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition3, _cardsPos[3]);
                    _setFlag = false;
                }
            }
            int rand = Random.Range(0, _enemyHandField.transform.childCount);
            _cards[rand] = _enemyHandField.transform.GetChild(rand).gameObject;
            GameObject[] positions = { _cardPosition, _cardPosition1, _cardPosition2, _cardPosition3, _cardPosition4, _cardPosition5, _cardPosition6, _cardPosition7, _cardPosition8 };
            while (_setFlag == true)
            {
                int randam = Random.Range(0, positions.Length);
                GameObject selectPosition = positions[randam];
                DropPlace dropPlace = selectPosition.GetComponent<DropPlace>();
                if (dropPlace.exist == false)
                {
                    dropPlace.exist = true;
                    EnemySetCard(_cards[rand], selectPosition, _cardsPos[randam]);
                    _setFlag = false;
                    Debug.Log("count");
                }
            }
            _pos6 = false;
        }
        else if (_cardPosition7.GetComponent<DropPlace>().playerExist == true && _pos7 == true)
        {
            _setFlag = true;
            for (int i = 0; i < _enemyHandField.transform.childCount; i++)
            {
                Card card = _cardPosition7.transform.GetChild(1).gameObject.GetComponent<Card>();
                _cards[i] = _enemyHandField.transform.GetChild(i).gameObject;
                if (_cards[i].GetComponent<Card>().numberTop > card.numberBottom && _cardPosition8.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition8.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition8, _cardsPos[8]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberBottom > card.numberTop && _cardPosition6.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition6.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition6, _cardsPos[6]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberLeft > card.numberRight && _cardPosition4.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition4.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition4, _cardsPos[4]);
                    _setFlag = false;
                }
            }
            int rand = Random.Range(0, _enemyHandField.transform.childCount);
            _cards[rand] = _enemyHandField.transform.GetChild(rand).gameObject;
            GameObject[] positions = { _cardPosition, _cardPosition1, _cardPosition2, _cardPosition3, _cardPosition4, _cardPosition5, _cardPosition6, _cardPosition7, _cardPosition8 };
            while (_setFlag == true)
            {
                int randam = Random.Range(0, positions.Length);
                GameObject selectPosition = positions[randam];
                DropPlace dropPlace = selectPosition.GetComponent<DropPlace>();
                if (dropPlace.exist == false)
                {
                    dropPlace.exist = true;
                    EnemySetCard(_cards[rand], selectPosition, _cardsPos[randam]);
                    _setFlag = false;
                }
            }
            _pos7 = false;
        }
        else if (_cardPosition8.GetComponent<DropPlace>().playerExist == true && _pos8 == true)
        {
            _setFlag = true;
            for (int i = 0; i < _enemyHandField.transform.childCount; i++)
            {
                Card card = _cardPosition8.transform.GetChild(1).gameObject.GetComponent<Card>();
                _cards[i] = _enemyHandField.transform.GetChild(i).gameObject;
                if (_cards[i].GetComponent<Card>().numberBottom > card.numberTop && _cardPosition7.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition7.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition7, _cardsPos[7]);
                    _setFlag = false;
                }
                else if (_cards[i].GetComponent<Card>().numberLeft > card.numberRight && _cardPosition5.GetComponent<DropPlace>().exist == false && _setFlag == true)
                {
                    DropPlace dropPlace = _cardPosition5.GetComponent<DropPlace>();
                    dropPlace.exist = true;
                    EnemySetCard(_cards[i], _cardPosition5, _cardsPos[5]);
                    _setFlag = false;
                }
            }
            int rand = Random.Range(0, _enemyHandField.transform.childCount);
            _cards[rand] = _enemyHandField.transform.GetChild(rand).gameObject;
            GameObject[] positions = { _cardPosition, _cardPosition1, _cardPosition2, _cardPosition3, _cardPosition4, _cardPosition5, _cardPosition6, _cardPosition7, _cardPosition8 };
            while (_setFlag == true)
            {
                int randam = Random.Range(0, positions.Length);
                GameObject selectPosition = positions[randam];
                DropPlace dropPlace = selectPosition.GetComponent<DropPlace>();
                if (dropPlace.exist == false)
                {
                    dropPlace.exist = true;
                    EnemySetCard(_cards[rand], selectPosition, _cardsPos[randam]);
                    _setFlag = false;
                }
            }
            _pos8 = false;
        }
        else if(_posStart == true)
        {
            _setFlag = true;
            int rand = Random.Range(0, _enemyHandField.transform.childCount);
            _cards[rand] = _enemyHandField.transform.GetChild(rand).gameObject;
            GameObject[] positions = { _cardPosition, _cardPosition1, _cardPosition2, _cardPosition3, _cardPosition4, _cardPosition5, _cardPosition6, _cardPosition7, _cardPosition8 };
            while (_setFlag == true)
            {
                int randam = Random.Range(0, positions.Length);
                GameObject selectPosition = positions[randam];
                DropPlace dropPlace = selectPosition.GetComponent<DropPlace>();
                if (dropPlace.exist == false)
                {
                    dropPlace.exist = true;
                    EnemySetCard(_cards[rand], selectPosition, _cardsPos[randam]);
                    _setFlag = false;
                    CardTop cardTop = _cards[rand].transform.GetChild(1).gameObject.GetComponent<CardTop>();
                    CardBottom cardBottom = _cards[rand].transform.GetChild(2).gameObject.GetComponent<CardBottom>();
                    CardRight cardRight = _cards[rand].transform.GetChild(3).gameObject.GetComponent<CardRight>();
                    CardLeft cardLeft = _cards[rand].transform.GetChild(4).gameObject.GetComponent<CardLeft>();
                    //cardTop.battleTop = false;
                    //cardBottom.battleBottom = false;
                    //cardRight.battleRight = false;
                    //cardLeft.battleLeft = false;
                    Debug.Log("count");
                }
            }
            _posStart = false;
        }
    }

    private void EnemySetCard(GameObject gameObject, GameObject gameObject1, Vector3 card)
    {
        //�J�[�h�̐e���t�B�[���h��
        gameObject.transform.SetParent(gameObject1.transform);
        //�J�[�h�̈ʒu��e(�t�B�[���h)�̂O�̈ʒu�ɐݒ�
        gameObject.transform.localPosition = Vector3.zero;
        //�J�[�h�ݒu�t���O�ƃJ�[�h���݃t���O�𗧂Ă�
        gameObject.GetComponent<CardMove>().setCard = true;
        //�^�[������シ��
        _gameManager.turn = !_gameManager.turn;
        //once�t���O�𗧂Ă�
        _once = true;

        //�v���C���[�̃J�[�h�Ȃ�ɁA�G�l�~�[�̃J�[�h�Ȃ�Ԃɕς���
        if (gameObject.tag == "Player")
        {
            Transform canvas = gameObject.transform.Find("Canvas");
            canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(0, 0, 255, 255);
        }
        else if (gameObject.tag == "Enemy")
        {
            Transform canvas = gameObject.transform.Find("Canvas");
            canvas.transform.Find("Frame").GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
    }
}
