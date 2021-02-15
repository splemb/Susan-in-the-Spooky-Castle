using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMagic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Geometry":
                Destroy(gameObject);
                break;
            case "LightBlock":
                collision.SendMessage("ChangeState", SendMessageOptions.DontRequireReceiver);
                Destroy(gameObject);
                break;
        }
    }
}
