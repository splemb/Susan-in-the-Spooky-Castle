using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZone : MonoBehaviour
{

    private new BoxCollider2D collider;

    public Sprite newBackground;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                Camera.main.GetComponent<CameraController>().upperBounds = collider.bounds.center + collider.bounds.extents;
                Camera.main.GetComponent<CameraController>().lowerBounds = collider.bounds.center - collider.bounds.extents;
                Camera.main.GetComponentInChildren<SpriteRenderer>().sprite = newBackground;
                break;
        }

    }
}
