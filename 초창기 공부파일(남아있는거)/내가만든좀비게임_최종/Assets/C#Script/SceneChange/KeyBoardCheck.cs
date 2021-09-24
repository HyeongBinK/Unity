using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyBoardCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
            SceneManager.LoadScene("MainScene");
        else if (Input.GetKey(KeyCode.Keypad2))
            Application.Quit();
    }
}
