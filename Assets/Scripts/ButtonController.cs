using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isActive;

    public bool oneUse;

    private bool used;

    public Sprite[] sprites;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player" || collision.tag == "Physics") && !used) { isActive = !isActive; GetComponent<SpriteRenderer>().sprite = sprites[1]; audioSource.Play(); if (oneUse) used = true; }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.tag == "Player" || collision.tag == "Physics") && !used) { GetComponent<SpriteRenderer>().sprite = sprites[0]; }
    }
}
