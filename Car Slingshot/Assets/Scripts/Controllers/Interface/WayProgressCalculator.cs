using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayProgressCalculator : MonoBehaviour
{

    CubeInfo currentCube;

    float minWayProgress;
    float maxWayProgress;

    Vector3 minWayProgressPosition;
    Vector3 maxWayProgressPosition;

    float oneWayProgressPercent;

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.TryGetComponent<CubeInfo>(out currentCube))
        {
            minWayProgressPosition = currentCube.GetLeftPosition();
            maxWayProgressPosition = currentCube.GetLeftForwardPosition();

            minWayProgress = currentCube.minWayProgressPercent;
            maxWayProgress = currentCube.maxWayProgressPercent;

            oneWayProgressPercent = (maxWayProgressPosition - minWayProgressPosition).magnitude / (maxWayProgress - minWayProgress);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentCube!=null)
        {
            Vector3 wayOfCubeProgressPosition = transform.position - minWayProgressPosition;
            float wayOfCubeProgress = wayOfCubeProgressPosition.magnitude / oneWayProgressPercent;
            EventManager.UpdateProgressInfo(minWayProgress + wayOfCubeProgress);
        }
    }
}
