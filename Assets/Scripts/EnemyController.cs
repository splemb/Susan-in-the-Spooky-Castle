using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed;
    public int health = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        switch (tag)
        {
            case "Enemy/Bimble":
                rb.velocity = Vector3.right * speed;
                break;
            case "Enemy/Snork":
                rb.velocity = Vector3.right + Vector3.down * speed;
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health != 0)
        {
            switch (tag) {
                case "Enemy/Bimble":
                    if (Mathf.Abs(rb.velocity.x) < 0.2f)
                    {
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                        rb.velocity = Vector3.right * speed * transform.localScale.x;
                    }
                    break;
                case "Enemy/Snork":
                    if (rb.velocity.magnitude < 0.1f)
                    {
                        rb.velocity = -rb.velocity.normalized * speed;
                    }
                    break;

            }
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (damage >= 0) death();
    }

    void FlipGravity()
    {
        GetComponent<SpriteRenderer>().flipY = !GetComponent<SpriteRenderer>().flipY;
        rb.gravityScale *= -1;
    }

    void death()
    {
        health = 0;
        rb.freezeRotation = false;
        rb.angularVelocity = 170;
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(0, 10, 0), ForceMode2D.Impulse);
        GetComponent<SpriteRenderer>().color = Color.red;
        foreach (Collider2D collider in GetComponents<Collider2D>()) collider.enabled = false;
        StartCoroutine("remove");
    }

    IEnumerator remove()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        
    }
}
