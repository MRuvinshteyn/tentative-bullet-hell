using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            canvas.enabled = !canvas.enabled;
        }
        if (canvas.enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            canvas.enabled = false;
        }
    }
}
