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
        if (following.position.x - 10 < lowerBounds.x) fixedX = lowerBounds.x + 10;
        else if (following.position.x + 10 > upperBounds.x) fixedX = upperBounds.x - 10;
        if (following.position.y - 6 < lowerBounds.y) fixedY = lowerBounds.y + 6;
        else if (following.position.y + 6 > upperBounds.y) fixedY = upperBounds.y - 6;

        transform.position = new Vector3(fixedX, fixedY, -10);
    }
}
