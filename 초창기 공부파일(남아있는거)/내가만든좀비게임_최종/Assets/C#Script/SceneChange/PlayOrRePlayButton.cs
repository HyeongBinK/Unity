using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
        
//미션종료창에서 다시하기
public class PlayOrRePlayButton : MonoBehaviour
{
    public void OnClickButton()
    {
        SceneManager.LoadScene("MainScene");
    }
 
}
