using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Text recordsText;

    

    private void Start()
    {
        Profile currentProfile = DataSaver.GetRecord("you");
        if (currentProfile != null)
            recordsText.text = "Рекорд: " + currentProfile.time.ToString("0.0000");
        else
            recordsText.text = "Рекорд: 0";
    }

    public void StartGame()
    {
        SceneManager.LoadScene("lvl1_scene");
    }
    public void OpenScoreboardScene()
    {
        SceneManager.LoadScene("scoreboard_scene");
    }
}
