using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfter : MonoBehaviour
{
    public int destroyAfter;
    private int count;
    public bool destroyAfterNotVisible;
    public bool destroyAfterTimer;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < Camera.main.transform.position.x - 12 || transform.position.x > Camera.main.transform.position.x + 12) Destroy(gameObject);
        if (destroyAfterTimer)
        {
            count++;
            if (count > destroyAfter) Destroy(gameObject);
        }
    }
}
