using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDataSaver : MonoBehaviour
{

    void Start()
    {

        EventManager.OnWinTrace.AddListener(ChangeRecord);
    }

    private void ChangeRecord(float time)
    {
        StartCoroutine(ChangeRecordCoroutine(time));
    }

    private IEnumerator ChangeRecordCoroutine(float time)
    {
        yield return new WaitForEndOfFrame();
        DataSaver.ChangeRecord("you", time);
        yield break;
    }

}
