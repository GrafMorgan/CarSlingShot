using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenuController : MonoBehaviour
{
    [SerializeField] GameObject winMenu;
    [SerializeField] Text timeText;
    void Start()
    {
        EventManager.OnWinTrace.AddListener(ShowWinPanel);
    }

    private void ShowWinPanel(float time)
    {
        winMenu.SetActive(true);
        timeText.text = "Ваше время:\n" + time.ToString("0.0000");
    }
}
