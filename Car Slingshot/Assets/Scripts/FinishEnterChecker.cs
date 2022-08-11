using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishEnterChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EventManager.OnWinTriggerEnter.Invoke();
    }
}
