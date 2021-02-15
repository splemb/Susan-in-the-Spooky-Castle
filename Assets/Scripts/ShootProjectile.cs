using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectile;
    private SpriteRenderer sprite;

    public List<GameObject> spells;
    public int currentSpell;

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        projectile = spells[currentSpell];

        if (Input.GetButtonDown("Fire"))
        {
            GameObject shotProjectile;
            if (sprite.flipX) shotProjectile = Instantiate(projectile, new Vector2(transform.position.x - 0.4f, transform.position.y + 0.5f), Quaternion.identity);
            else shotProjectile = Instantiate(projectile, new Vector2(transform.position.x + 0.4f, transform.position.y + 0.5f), Quaternion.identity);
            shotProjectile.GetComponent<SpriteRenderer>().flipX = sprite.flipX;
            if (sprite.flipX) shotProjectile.GetComponent<Rigidbody2D>().velocity = -Vector2.right;
            else shotProjectile.GetComponent<Rigidbody2D>().velocity = Vector2.right;
            shotProjectile.GetComponent<Rigidbody2D>().velocity *= 20f;
            GetComponent<PlayerController>().audioSource.PlayOneShot(GetComponent<PlayerController>().sounds[1]);
        }

        if (Input.GetButtonDown("Next"))
        {
            currentSpell++;
            if (currentSpell > spells.Count - 1) currentSpell = 0;
        }

        if (Input.GetButtonDown("Previous"))
        {
            currentSpell--;
            if (currentSpell < 0) currentSpell = spells.Count - 1;
        }
    }

    private void GetSpell(GameObject spell)
    {
        spells.Add(spell);
        currentSpell = spells.Count - 1;
    }
}
