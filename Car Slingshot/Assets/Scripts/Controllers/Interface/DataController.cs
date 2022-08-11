using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataController : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] Text wayText;
    [SerializeField] Text powerText;

    void Start()
    {
        EventManager.OnPowerInfoUpdate.AddListener(PowerUpdate);
        EventManager.OnTimeInfoUpdate.AddListener(TimeUpdate);
        EventManager.OnProgressInfoUpdate.AddListener(ProgressUpdate);
    }

    private void TimeUpdate(float time)
    {
        timeText.text = "Время: " + time.ToString("0.0000");
    }
    private void PowerUpdate(float power)
    {
        powerText.text = "Сила натяжения: " + ((int)(power*100)).ToString() + "%";
    }
    private void ProgressUpdate(float progress)
    {
        wayText.text = "Пройдено: " + ((int)progress).ToString() + "%";
    }
}
