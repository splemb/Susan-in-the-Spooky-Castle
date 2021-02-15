using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlock : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;

    public bool defaultState;
    private bool state;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        state = defaultState;
    }

    // Update is called once per frame
    void Update()
    {
        boxCollider.isTrigger = !state;

        if (state) { sprite.sprite = sprites[0]; gameObject.layer = 9; }
        else {sprite.sprite = sprites[1]; gameObject.layer = 9;}
    }

    public void ChangeState()
    {
        state = !state;
    }
}
