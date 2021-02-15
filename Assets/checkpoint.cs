using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private void Start()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                if (GetComponentInChildren<SpriteRenderer>().color != Color.white)
                {
                    collision.SendMessage("updateRespawnPoint", transform.position, SendMessageOptions.DontRequireReceiver);
                    foreach (GameObject checkpoint in GameObject.FindGameObjectsWithTag("Checkpoint")) checkpoint.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                    GetComponentInChildren<SpriteRenderer>().color = Color.white;
                    GetComponent<AudioSource>().Play();
                }
                break;
        }
    }
}
