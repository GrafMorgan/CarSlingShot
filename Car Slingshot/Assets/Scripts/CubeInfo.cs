using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInfo : MonoBehaviour
{
    [SerializeField] Transform leftPosition;
    [SerializeField] Transform rightPosition;
    [SerializeField] Transform leftForwardPosition;
    [SerializeField] Transform rightForwardPosition;

    public float minWayProgressPercent { private set; get; }
    public float maxWayProgressPercent { private set; get; }

    public Vector3 GetLeftPosition()
    {
        return leftPosition.position;
    }
    public Vector3 GetRightPosition()
    {
        return rightPosition.position;
    }
    public Vector3 GetLeftForwardPosition()
    {
        return leftForwardPosition.position;
    }
    public Vector3 GetRightForwardPosition()
    {
        return rightForwardPosition.position;
    }

    public void SetMinWay(float min)
    {
        minWayProgressPercent = min;
    }
    public void SetMaxWay(float max)
    {
        maxWayProgressPercent = max;
    }
}
