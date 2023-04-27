using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    bool timerActive = false;
    float currentTime;
    public int startMinutes;
    public Text currentTimeText;

    public static int totalTimeMin1 = 0;
    public static int totalTimeSec1 = 0;
    public static float totalTimeMS1 = 0;

    public static int totalTimeMin2 = 0;
    public static int totalTimeSec2 = 0;
    public static float totalTimeMS2 = 0;

    public static int totalTimeMin3 = 0;
    public static int totalTimeSec3 = 0;
    public static float totalTimeMS3 = 0;

    //Scene currentScene = SceneManager.GetActiveScene();
    //string sceneName = currentScene.name;
    // Start is called before the first frame update
    void Start()
    {
        timerActive = true;
        currentTime = startMinutes * 60;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        
        if(time.Seconds < 10)
        {
            currentTimeText.text = "0" + time.Minutes.ToString() + ":" + "0" + time.Seconds.ToString() + "." + time.Milliseconds.ToString();
        }
        else
        {
            currentTimeText.text = "0" + time.Minutes.ToString() + ":" + time.Seconds.ToString() + "." + time.Milliseconds.ToString();
        }
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            totalTimeMin1 = time.Minutes;
            totalTimeSec1 = time.Seconds;
            totalTimeMS1 = time.Milliseconds;
        }
        if(SceneManager.GetActiveScene().name == "Level2")
        {
            totalTimeMin2 = time.Minutes;
            totalTimeSec2 = time.Seconds;
            totalTimeMS2 = time.Milliseconds;
        }
        if(SceneManager.GetActiveScene().name == "Level3")
        {
            totalTimeMin3 = time.Minutes;
            totalTimeSec3 = time.Seconds;
            totalTimeMS3 = time.Milliseconds;
        }
    }
}
