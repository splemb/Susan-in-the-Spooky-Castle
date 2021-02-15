using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void FlipGravity()
    {
        rb.gravityScale *= -1;
    }

    private void Update()
    {
        sprite.transform.Rotate(0, 0, rb.velocity.magnitude * -rb.velocity.normalized.x * Mathf.Sign(rb.gravityScale));
    }
}
