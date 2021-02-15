using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public int destroyAfter;
    private int count;

    private bool dead;

    private void Start()
    {
        count = 0;
    }

    void Update()
    {
        if (dead) count++;

        if (count > destroyAfter) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Magic")
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            dead = true;
            Destroy(collision.gameObject);
        }
    }
}
