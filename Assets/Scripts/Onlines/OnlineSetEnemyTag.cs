using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineSetEnemyTag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            if (collision.gameObject.name == "OnlineCard(Clone)")
            {
                collision.gameObject.tag = "Enemy";
                Debug.Log(collision.tag);
            }
        }
    }
}
