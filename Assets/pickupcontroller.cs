using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupcontroller : MonoBehaviour
{
    public GameObject projectile;

    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                collision.SendMessage("GetSpell",projectile);
                collision.GetComponent<AudioSource>().PlayOneShot(sound);
                Destroy(gameObject);
                break;
        }
    }
}
