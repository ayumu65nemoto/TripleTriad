using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineSetTag : MonoBehaviour
{
    [SerializeField] OnlineGameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.name == "OnlineCard(Clone)")
            {
                collision.gameObject.tag = "Player";
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("des");
        if (_gameManager.gameSet == true)
        {
            Destroy(collision.gameObject);
            Debug.Log("desed");
        }
    }
}
