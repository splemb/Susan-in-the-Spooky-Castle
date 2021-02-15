using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Sprite[] sprites;
    public ButtonController button;
    private BoxCollider2D boxCollider;

    public bool defaultState;
    private bool state;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        //if (button != null) GetComponent<SpriteRenderer>().color = button.GetComponent<SpriteRenderer>().color;
        state = defaultState;
    }

    // Update is called once per frame
    void Update()
    {
        boxCollider.isTrigger = !state;
        if (state) GetComponent<SpriteRenderer>().sprite = sprites[0];
        else GetComponent<SpriteRenderer>().sprite = sprites[1];

        if (button != null)
        {
            if (defaultState) state = !button.isActive;
            else state = button.isActive;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Magic")
        {
            state = !state;
            Destroy(collision.gameObject);
        }
    }
}
