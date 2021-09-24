using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserResultInterFace : MonoBehaviour
{
    Rect ScorePosition;
    Rect TimePosition;
    Rect FianlScorePosition;
    GameObject FindResult;

    public int Score;
    public float time;
    public float FinalScore;

    // Start is called before the first frame update
    void Start()
    {
        ScorePosition = new Rect(520, 285, 100, 30);
        TimePosition = new Rect(700, 285, 100, 30);
        FianlScorePosition = new Rect(950, 285, 100, 30);
        FindResult = GameObject.Find("GOALZONE");
        Score = FindResult.GetComponent<MissionComplete>().KillScore;
        time = FindResult.GetComponent<MissionComplete>().ResultTime;
        FinalScore = 600 + Score - time * 10;
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void OnGUI()
    {
        GUI.Label(ScorePosition, Score.ToString());
        GUI.Label(TimePosition, time.ToString());
        GUI.Label(FianlScorePosition, FinalScore.ToString());
    }
}
