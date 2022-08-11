using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowInfo : MonoBehaviour
{

    [SerializeField] Text nameText;
    [SerializeField] Text numberText;
    [SerializeField] Text timeText;

    public void SetRowData(int number, string name, float time)
    {
        numberText.text = number.ToString();
        nameText.text = name;
        timeText.text = time.ToString("0.0000");
    }
}
