using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystemInfo : MonoBehaviour
{
    public static GameSystemInfo Instance { get; private set; }
    
    public Text TimerText;
    public Text ScoreText;

    public GameObject settingUI;
    
    void Awake()
    {
        Instance = this;
    }

    public void UpdateTimer(float time)
    {
        TimerText.text = time.ToString("N1");
    }

    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
    }

    public void ClickSetting()
    {
        settingUI.SetActive(true);
    }

    public void ClickScore() { }

    public void NormalAttack()
    {
        Debug.LogFormat("normal attack, need a skill");
    }
}
