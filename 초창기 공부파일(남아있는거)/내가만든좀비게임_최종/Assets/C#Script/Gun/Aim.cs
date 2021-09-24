using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    //메인카메라에 에임
    public Texture2D AimTexture;
    Rect AimRect;

    // Start is called before the first frame update
    void Start()
    {
        float x1, y1, x2, y2;

        x1 = (Screen.width - AimTexture.width) / 2;
        y1 = (Screen.height - AimTexture.height) / 2;
        x2 = AimTexture.width;
        y2 = AimTexture.height;

        AimRect = new Rect(x1, y1, x2, y2);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnGUI()
    {
        GUI.DrawTexture(AimRect, AimTexture);
    }
}
