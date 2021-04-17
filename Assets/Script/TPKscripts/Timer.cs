using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer timer;

    public Text timerText;

    private TimeSpan playTime;
    private bool goTime;
    private float elapsedTime;

    private void Awake()
    {
        timer = this;
    }

    private void Start()
    {
        timerText.text = "00 : 00 . 00";
        goTime = false;
    }
    public void beginTimer()
    {
        goTime = true;
        elapsedTime = 0f;

        StartCoroutine(updateTimer());
    }
    public void endTimer()
    {
        goTime = false;
    }

    private IEnumerator updateTimer()
    {
        while (goTime)
        {
            elapsedTime += Time.deltaTime;
            playTime = TimeSpan.FromSeconds(elapsedTime);
            string timePlayString = playTime.ToString("mm' : 'ss' . 'ff");
            timerText.text = timePlayString;

            yield return null;
        }
    }
}
