using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform following;
    private Vector3 lowerCamera;
    private Vector3 upperCamera;

    public Vector2 lowerBounds;
    public Vector2 upperBounds;

    // Start is called before the first frame update
    void Start()
    {
        following = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float fixedX = following.position.x;
        float fixedY = following.position.y;
        if (following.position.x < lowerBounds.x) fixedX = lowerBounds.x;
        else if (following.position.x > upperBounds.x) fixedX = upperBounds.x;
        if (following.position.y < lowerBounds.y) fixedY = lowerBounds.y;
        else if (following.position.y > upperBounds.y) fixedY = upperBounds.y;

        transform.position = new Vector3(fixedX, fixedY, -10);
    }
}
