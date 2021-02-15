using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerdoor : MonoBehaviour
{

    public Sprite[] sprites;
    public bool open;
    public new BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open) collider.enabled = false;
        else collider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            open = true;
            if (collision.transform.position.x > transform.position.x) transform.localScale = new Vector3(-1,1,1);
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
            open = false;
            transform.localScale = Vector3.one;
            GetComponent<AudioSource>().Play();
        }
    }
}
