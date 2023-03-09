using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineSetTag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.name == "OnlineCard(Clone)")
            {
                collision.gameObject.tag = "Player";
                Debug.Log(collision.tag);
            }
        }
    }
}
