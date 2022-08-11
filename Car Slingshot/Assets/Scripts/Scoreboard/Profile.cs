using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Profile
{
    public string name;
    public float time;
    public DateTime date;

    public Profile(string name, float time, DateTime date)
    {
        this.name = name;
        this.time = time;
        this.date = date;
    }
}
