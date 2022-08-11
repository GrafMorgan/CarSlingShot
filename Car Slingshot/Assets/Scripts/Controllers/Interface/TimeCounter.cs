using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    bool isPlaying = true;
    float time;

    void Start()
    {
        time = 0;
        EventManager.OnWinTriggerEnter.AddListener(WinTrace);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            time += Time.deltaTime;
            EventManager.UpdateTimeInfo(time);
        }
    }

    private void WinTrace()
    {
        EventManager.WinTrace(time);
        isPlaying = false;
    }
}
