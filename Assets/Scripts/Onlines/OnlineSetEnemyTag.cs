using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineSetEnemyTag : MonoBehaviour
{
    [SerializeField] OnlineGameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            if (collision.gameObject.name == "OnlineCard(Clone)")
            {
                collision.gameObject.tag = "Enemy";
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_gameManager.gameSet == true)
        {
            Destroy(collision.gameObject);
            Debug.Log("des");
        }
    }
}
