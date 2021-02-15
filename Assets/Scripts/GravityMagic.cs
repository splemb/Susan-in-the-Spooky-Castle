using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMagic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Geometry":
                Destroy(gameObject);
                break;

            case "LightBlock":
                Destroy(gameObject);
                break;
            case "Enemy/Bimble":
                collision.SendMessage("FlipGravity", SendMessageOptions.DontRequireReceiver);
                Destroy(gameObject);
                break;
            case "Physics":
                collision.SendMessage("FlipGravity", SendMessageOptions.DontRequireReceiver);
                Destroy(gameObject);
                break;
        }
    }
}
