using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
   public static UIMgr instance { get; private set; }

    [SerializeField] private Text timer;
    [SerializeField] private Text gameOverText;
    private GameObject gameOverPanel;

    public float Timer
    {
        set { if (timer) timer.text = string.Format("Timer : {0:N2}", value); }
    }

    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (gameOverText) gameOverPanel = gameOverText.transform.parent.gameObject;
            return;
        }
        Destroy(gameObject);
    }

    public void GameOver(float time)
    {
        if(gameOverText && gameOverPanel)
        {
            var bestTime = PlayerPrefs.GetFloat("BestTime", 0);
            bestTime = Mathf.Max(bestTime, time);

            gameOverText.text = string.Format("<b>Press <color=red>R</color> to Restart</b>\n<i>Best Time : {0:N2}</i>", bestTime);

            PlayerPrefs.SetFloat("BestTime", bestTime);

            gameOverPanel.SetActive(true);
        }
    }

    public void OnPlay() { if (gameOverPanel) gameOverPanel.SetActive(false); }
}
