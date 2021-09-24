using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void OnClickButton()
    {
        print("게임종료");
        Application.Quit();
    }

}
