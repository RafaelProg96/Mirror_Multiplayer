using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text teamAPointsText, teamBPointsText, colum;

    private void Start()
    {
        teamAPointsText.color = Color.magenta;
        teamBPointsText.color = Color.yellow;
        
        colum.color = Color.cyan;
        colum.text = ":";

        UpdateScoreText(0,0);
    }

    public void UpdateScoreText(int teamAPoints, int teamBPoints)
    {
        teamAPointsText.text = teamAPoints.ToString();
        teamBPointsText.text = teamBPoints.ToString();
    }
}