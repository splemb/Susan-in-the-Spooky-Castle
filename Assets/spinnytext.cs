using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinnytext : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-Vector3.forward * 0.3f);
        transform.localScale *= 1.001f;

        if (Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
}
