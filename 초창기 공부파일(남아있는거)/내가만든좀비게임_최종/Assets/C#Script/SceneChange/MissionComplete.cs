using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//골인지점에 도착하면 게임종료화면으로 전환
public class MissionComplete : MonoBehaviour
{
    public int KillScore;
    public float ResultTime;
    public GameObject Result;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            KillScore = Camera.main.GetComponent<UserInterFace>().CurrentScore;
            ResultTime = Camera.main.GetComponent<UserInterFace>().time;
            print("미션성공");
            SceneManager.LoadScene("GameOverScene");
            DontDestroyOnLoad(Result);
        }
    }
}
