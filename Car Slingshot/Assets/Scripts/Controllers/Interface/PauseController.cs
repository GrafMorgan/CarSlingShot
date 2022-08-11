using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject pausePanel;

    public void Start()
    {
        EventManager.OnWinTriggerEnter.AddListener(DisablePauseButton);
    }

    public void PauseButtonClick()
    {
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0;

        EventManager.ChangePauseSate(true);
    }
    public void ContinueButtonClick()
    {
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1;

        EventManager.ChangePauseSate(false);
    }
    public void RestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainmenu_scene");
    }
    private void DisablePauseButton()
    {
        pauseButton.SetActive(false);
    }


}
