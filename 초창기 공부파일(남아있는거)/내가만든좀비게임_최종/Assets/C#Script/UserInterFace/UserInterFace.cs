using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterFace : MonoBehaviour
{
    //게임점수
    Rect ScorePosition;
    Rect TimePosition;
    public int CurrentScore = 0;
    public Slider HealthBar;
    public float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScorePosition = new Rect(Screen.width - 100, 30, 100, 30);
        TimePosition = new Rect(53, 41, 100, 30);
        print("좀비를피해 안전구역(Goal)까지 이동해라!!");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (HealthBar.value == 0)
        {
            print("캐릭터사망");
            SceneManager.LoadScene("YouDied");
        }
    }

    private void OnGUI()
    {
        GUI.Label(ScorePosition, CurrentScore.ToString());
        GUI.Label(TimePosition, time.ToString());
    }

}
