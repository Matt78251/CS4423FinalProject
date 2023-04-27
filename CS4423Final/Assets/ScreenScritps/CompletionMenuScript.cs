using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class CompletionMenuScript : MonoBehaviour
{

    public Text timeText;
    public Text pointsText;
    public Text heartsText;
    public Text artifactsText;
    private double points = 0.0;
    private int hearts = 0;
    private int artifacts = 0;
    private int cMins = 0;
    private int cSecs = 0;
    private float cMS = 0;
    private int totalSeconds = 0;


    public void Start()
    {
        PrintValues();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }

    public void PrintValues()
    {
        cMins = Timer.totalTimeMin1 + Timer.totalTimeMin2 + Timer.totalTimeMin3;
        cSecs = Timer.totalTimeSec1 + Timer.totalTimeSec2 + Timer.totalTimeSec3;
        cMS = Timer.totalTimeMS1 + Timer.totalTimeMS2 + Timer.totalTimeMS3;

        if(cSecs > 120)
        {
            cSecs -= 60;
            cMins++;
        }
        if(cSecs > 60)
        {
            cSecs -= 60;
            cMins++;
        }


        if(cMS > 2000)
        {
            cMS -= 1000;
            cSecs++;
            totalSeconds++;

        }
        if(cMS > 1000)
        {
            cMS -= 1000;
            cSecs++;
            totalSeconds++;
        }


        totalSeconds += cSecs;
        totalSeconds = totalSeconds + (60 * cMins);


        timeText.text = "Total Time: " + cMins.ToString() + ":" + cSecs.ToString() + "." + cMS.ToString();

        hearts = PlayerHealth.totalHearts1 + PlayerHealth.totalHearts2 + PlayerHealth.totalHearts3;
        heartsText.text = "Total Hearts: " + hearts.ToString();

        artifacts = PlayerHealth.totalArtifacts1 + PlayerHealth.totalArtifacts2 + PlayerHealth.totalArtifacts3;
        artifactsText.text = "Total Artifacts: " + artifacts.ToString();

        points = artifacts + hearts;
        points /= totalSeconds;
        points *= 1000;
        points = Math.Ceiling(points);
        
        pointsText.text = "Total Points: " + points.ToString();
    }


}
