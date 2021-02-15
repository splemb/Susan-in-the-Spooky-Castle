using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    [SerializeField] public LayerMask Ground;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    public AudioSource audioSource;
    public AudioClip[] sounds;

    public bool willJump;
    public float canJump;
    public bool doubleJumped;

    public int health = 10;

    private bool dead = false;

    private int controlLock = 0;

    private int invincible = 0;

    private Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Only register jump if on the ground
        checkCanJump();

        if ((canJump > 0) && Input.GetButtonDown("Jump"))
        {
            willJump = true;
            canJump = 0;
        } else if (!doubleJumped && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, -rb.velocity.y), ForceMode2D.Impulse);
            willJump = true;
            doubleJumped = true;
            GetComponent<ParticleSystem>().Play();
        }

        if (transform.position.y < Camera.main.GetComponent<CameraController>().lowerBounds.y - 8 && !dead) death();

        
    }

    private void FixedUpdate()
    {
        if (controlLock <= 0)
        {
            controlLock = 0;
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                //transform.localScale = new Vector3(1,transform.localScale.y, transform.localScale.z);
                sprite.flipX = false;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                //transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                sprite.flipX = true;
            }

            if (willJump)
            {
                audioSource.PlayOneShot(sounds[0]);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                willJump = false;
                if (doubleJumped) rb.AddForce(-Vector2.up * jumpForce * 0.3f, ForceMode2D.Impulse);
            }

            if (rb.velocity.y > 0.2 && !Input.GetButton("Jump"))
            {
                rb.velocity += new Vector2(0f, -rb.velocity.y);
            }

            rb.AddForce(new Vector2((Input.GetAxis("Horizontal") * speed) - rb.velocity.x, 0), ForceMode2D.Impulse);
        }

        else { controlLock--;}

        animator.SetFloat("hVelocity", Mathf.Abs(rb.velocity.x));

        if (invincible > 0)
        {
            invincible--;
            sprite.color = Color.red;
            if (invincible % 4 == 0) sprite.enabled = !sprite.enabled;
        } else
        {
            invincible = 0;
            sprite.color = Color.white;
            sprite.enabled = true;
        }
    }

    private void checkCanJump()
    {
        if (isGrounded())
        {
            doubleJumped = false;
            canJump = 0.05f;
            
        } else if (canJump > 0)
        {
            canJump -= Time.deltaTime;
        }
        else
        {
            canJump = 0;
        }
    }

    private bool isGrounded()
    {
        // Cast a box straight down
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(0.3f,0.1f), 0f, -Vector2.up, 0.1f, Ground);

        // Return if it hits the ground
        return (hit.collider != null);
    }

    private void updateRespawnPoint(Vector3 point)
    {
        respawnPoint = point;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy/Bimble" || collision.gameObject.tag == "Enemy/Snork" || collision.gameObject.tag == "Spike") && invincible == 0)
        {
            controlLock = 10;
            invincible = 120;
            if (health > 1)
            {
                health--;
                audioSource.PlayOneShot(sounds[2]);
                if (collision.transform.position.x > transform.position.x + sprite.bounds.size.x / 2)
                {
                    rb.AddForce(new Vector3(-10 - rb.velocity.x,0), ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(new Vector3(10 - rb.velocity.x,0), ForceMode2D.Impulse);
                }
                if (collision.transform.position.y > transform.position.y + sprite.bounds.size.y / 2)
                {
                    rb.AddForce(new Vector3(0, -10 - rb.velocity.y), ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(new Vector3(0, 10 - rb.velocity.y), ForceMode2D.Impulse);
                }
            }
            else death();

            willJump = false;
            canJump = 0;
        }
    }

    private void death()
    {
        audioSource.PlayOneShot(sounds[3]);
        dead = true;
        health = 0;
        controlLock = 99999;
        rb.AddForce(new Vector3(-rb.velocity.x, 10 - rb.velocity.y), ForceMode2D.Impulse);
        GetComponent<Collider2D>().enabled = false;
        Debug.Log("YOU DIEEEEED");
        StartCoroutine("reload");
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(2);

        health = 10;
        GetComponent<Collider2D>().enabled = true;
        controlLock = 0;
        transform.position = respawnPoint;
        sprite.flipX = false;
        dead = false;
        sprite.enabled = true;
        invincible = 0;
    }
}
