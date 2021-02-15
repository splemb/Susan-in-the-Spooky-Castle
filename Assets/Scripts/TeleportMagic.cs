using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMagic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Geometry":
                if (GetComponent<SpriteRenderer>().flipX) GameObject.FindGameObjectWithTag("Player").transform.position = transform.position + Vector3.right;
                else GameObject.FindGameObjectWithTag("Player").transform.position = transform.position - Vector3.right;
                Destroy(gameObject);
                break;

            case "LightBlock":
                if (GetComponent<SpriteRenderer>().flipX) GameObject.FindGameObjectWithTag("Player").transform.position = transform.position + Vector3.right;
                else GameObject.FindGameObjectWithTag("Player").transform.position = transform.position - Vector3.right;
                Destroy(gameObject);
                break;
        }
    }
}
