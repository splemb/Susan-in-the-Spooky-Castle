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
                if (GetComponent<SpriteRenderer>().flipX) GameObject.FindGameObjectWithTag("Player").transform.position = transform.position + (Vector3.right * 0.5f);
                else GameObject.FindGameObjectWithTag("Player").transform.position = transform.position - (Vector3.right * 0.5f);
                Destroy(gameObject);
                break;

            case "LightBlock":
                if (GetComponent<SpriteRenderer>().flipX) GameObject.FindGameObjectWithTag("Player").transform.position = transform.position + (Vector3.right*0.5f);
                else GameObject.FindGameObjectWithTag("Player").transform.position = transform.position - (Vector3.right * 0.5f);
                Destroy(gameObject);
                break;
            case "Physics":
                if (GetComponent<SpriteRenderer>().flipX) GameObject.FindGameObjectWithTag("Player").transform.position = transform.position + (Vector3.right * 0.5f);
                else GameObject.FindGameObjectWithTag("Player").transform.position = transform.position - (Vector3.right * 0.5f);
                Destroy(gameObject);
                break;
        }
    }
}
