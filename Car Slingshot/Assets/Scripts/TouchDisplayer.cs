using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDisplayer : MonoBehaviour
{
    [SerializeField] RectTransform startTouch;
    [SerializeField] RectTransform currentTouch;
    void Start()
    {
        EventManager.OnFingerDown.AddListener(SetStartTouch);
        EventManager.UpdateTouch.AddListener(UpdateCurrentTouchPosition);
        EventManager.HideHelpers.AddListener(HideTouches);
    }

    private void SetStartTouch()
    {
        startTouch.anchoredPosition = Input.touches[0].position - new Vector2(Screen.width, Screen.height)/2;
        startTouch.gameObject.SetActive(true);
        currentTouch.gameObject.SetActive(true);
    }

    private void UpdateCurrentTouchPosition()
    {
        currentTouch.anchoredPosition = Input.touches[0].position - new Vector2(Screen.width, Screen.height) / 2;
    }

    private void HideTouches()
    {
        startTouch.gameObject.SetActive(false);
        currentTouch.gameObject.SetActive(false);
    }
}
