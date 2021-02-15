using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Geometry":
                Destroy(gameObject);
                break;
            case "Enemy":
                collision.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
                Destroy(gameObject);
                break;
        }
    }
}
