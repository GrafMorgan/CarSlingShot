using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager 
{
    public static UnityEvent OnFingerDown = new UnityEvent();
    public static UnityEvent<float,float> OnChangePower = new UnityEvent<float,float>();
    public static UnityEvent<float, float> OnCarMove = new UnityEvent<float, float>();
    public static UnityEvent OnCarStop = new UnityEvent();
    public static UnityEvent<Vector3> OnCameraUpdate = new UnityEvent<Vector3>();
    public static UnityEvent<float> OnChangeCarRotation = new UnityEvent<float>();

    public static UnityEvent UpdateTouch = new UnityEvent();
    public static UnityEvent HideHelpers = new UnityEvent();

    public static UnityEvent<float> OnPowerInfoUpdate = new UnityEvent<float>();
    public static UnityEvent<float> OnTimeInfoUpdate = new UnityEvent<float>();
    public static UnityEvent<float> OnProgressInfoUpdate = new UnityEvent<float>();

    public static UnityEvent<bool> OnPauseStateChange = new UnityEvent<bool>();

    public static UnityEvent<float> OnWinTrace = new UnityEvent<float>();
    public static UnityEvent OnWinTriggerEnter = new UnityEvent();

    public static void FingerDown()
    {
        OnFingerDown.Invoke();
    }
    public static void UpdatePowerInfo(float power)
    {
        OnPowerInfoUpdate.Invoke(power);
    }
    public static void UpdateTimeInfo(float time)
    {
        OnTimeInfoUpdate.Invoke(time);
    }
    public static void UpdateProgressInfo(float progress)
    {
        OnProgressInfoUpdate.Invoke(progress);
    }
    public static void ChangePower(float power, float angle)
    {
        UpdatePowerInfo(power);
        OnChangePower.Invoke(power, angle);
        UpdateTouch.Invoke();
    }
    public static void MoveCar(float power, float angle)
    {
        OnCarMove.Invoke(power, angle);
        HideHelpers.Invoke();
    }
    public static void StopCar()
    {
        OnCarStop.Invoke();
    }
    public static void UpdateCamera(Vector3 carPosition)
    {
        OnCameraUpdate.Invoke(carPosition);
    }
    public static void ChangeCarRotation(float rotation)
    {
        OnChangeCarRotation.Invoke(rotation);
    }
    public static void ChangePauseSate(bool isPause)
    {
        OnPauseStateChange.Invoke(isPause);
    }
    public static void WinTrace(float time)
    {
        OnWinTrace.Invoke(time);
        ChangePauseSate(true);
    }
    public static void EnterWinTrigger()
    {
        OnWinTriggerEnter.Invoke();
    }
}
