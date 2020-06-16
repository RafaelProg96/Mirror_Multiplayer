using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text teamAPointsText, teamBPointsText, columText, timerText;
    private readonly int initialTimer = 120;
    private float timer;

    private void Start()
    {
        teamAPointsText.color = Color.magenta;
        teamBPointsText.color = Color.yellow;
        
        columText.color = Color.cyan;
        columText.text = ":";

        UpdateScoreText(0, 0);

        timer = initialTimer;
        StartTimer();
    }

    public void UpdateScoreText(int teamAPoints, int teamBPoints)
    {
        teamAPointsText.text = teamAPoints.ToString();
        teamBPointsText.text = teamBPoints.ToString();
    }

    public void UpdateTimerText(string time)
    {
        timerText.text = time;
    }

    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        float minutes = timer / 60f;
        minutes = (int)minutes;

        float seconds = timer % 60f;

        string time = minutes.ToString("f0") + ":" + seconds.ToString("00");
        UpdateTimerText(time);

        yield return new WaitForSeconds(1f);

        timer--;

        if (timer > 0) { StartTimer(); }
        else { yield return null; }
    }
}