using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Segment
{
    public float width;
    public float length;
    public float angle;
}

public class LevelConfigurator : MonoBehaviour
{
    [SerializeField] GameObject finishPrefab;
    [SerializeField] GameObject segmentPrefab;

    [SerializeField] List<Segment> segments = new List<Segment>();
    [SerializeField]private List<GameObject> segmentObjects = new List<GameObject>();

    private Transform finishObject;

    private IEnumerator DestroySegmentObject(int i)
    {
        yield return new WaitForSecondsRealtime(.0001f);
        DestroyImmediate(segmentObjects[i]);
        segmentObjects.RemoveAt(i);
        yield break; 
    }




    private void CheckCountOfSegments()
    {
        segmentObjects = new List<GameObject>();
        if (segmentObjects.Count < segments.Count)
        {

            if (transform.childCount > 1)
            {
                foreach (Transform child in transform)
                {
                    if (child.TryGetComponent<CubeInfo>(out CubeInfo ci)) segmentObjects.Add(child.gameObject);
                }
            }

            for (int i = segmentObjects.Count; i < segments.Count; i++)
            {
                var newSegmentObject = Instantiate(segmentPrefab, transform);
                segmentObjects.Add(newSegmentObject);
            }
        }
        if (segmentObjects.Count > segments.Count)
        {
            for (int i = segmentObjects.Count - 1; i >= segments.Count; i--)
            {
                StartCoroutine(DestroySegmentObject(i));
            }
        }

        if(finishObject == null)
        {
            if(transform.Find(finishPrefab.name))
            {
                finishObject = transform.Find(finishPrefab.name);
            }
            else
            {
                finishObject = Instantiate(finishPrefab, transform).transform;
                finishObject.name = finishPrefab.name;
            }
        }
    }

    private void SetWayProgress()
    {
        float sumWay = 0;
        for(int i = 0; i < segments.Count; i++)
        {
            sumWay += segments[i].length-1;
        }
        float oneProgressPercent = sumWay / 100;
        float movedWay = 0;
        for(int i = 0; i < segments.Count-1; i++)
        {
            segmentObjects[i].GetComponent<CubeInfo>().SetMinWay(movedWay + 1);
            segmentObjects[i].GetComponent<CubeInfo>().SetMaxWay(segmentObjects[i].GetComponent<CubeInfo>().minWayProgressPercent + (segments[i].length-1)/oneProgressPercent);

            movedWay = segmentObjects[i].GetComponent<CubeInfo>().maxWayProgressPercent;
        }
        segmentObjects[segmentObjects.Count - 1].GetComponent<CubeInfo>().SetMinWay(movedWay + 1);
        segmentObjects[segmentObjects.Count - 1].GetComponent<CubeInfo>().SetMaxWay(100);
    }

    private void ConfigurateCubes()
    {
        Vector3 positionOfLastSegment = Vector3.zero;
        Vector3 eulerOfSegment = Vector3.zero;

        for (int i = 0; i < segments.Count; i++)
        {
            Vector3 scaleOfSegment;
            Vector3 positionOfSegment;

            scaleOfSegment = new Vector3(segments[i].width, 1, segments[i].length);
            segmentObjects[i].transform.localScale = scaleOfSegment;

            eulerOfSegment = new Vector3(0, segments[i].angle, 0);
            segmentObjects[i].transform.eulerAngles = eulerOfSegment;

            positionOfSegment = positionOfLastSegment + segmentObjects[i].transform.rotation * (new Vector3(0, 0, segments[i].length / 2));
            segmentObjects[i].transform.localPosition = positionOfSegment - new Vector3(0,0.05f,0)*i;

            Vector3 correctPosition = Vector3.zero;

            if (i > 0)
            {

                if (segments[i].angle > segments[i - 1].angle)
                {
                    Vector3 leftPos = new Vector3(segmentObjects[i].GetComponent<CubeInfo>().GetLeftPosition().x, 0, segmentObjects[i].GetComponent<CubeInfo>().GetLeftPosition().z);
                    Vector3 leftFrontPos = new Vector3(segmentObjects[i - 1].GetComponent<CubeInfo>().GetLeftForwardPosition().x, 0, segmentObjects[i - 1].GetComponent<CubeInfo>().GetLeftForwardPosition().z);

                    correctPosition = leftPos - leftFrontPos;
                    segmentObjects[i].transform.position -= correctPosition;

                }
                else
                {
                    Vector3 rightPos = new Vector3(segmentObjects[i].GetComponent<CubeInfo>().GetRightPosition().x, 0, segmentObjects[i].GetComponent<CubeInfo>().GetRightPosition().z);
                    Vector3 rightFrontPos = new Vector3(segmentObjects[i - 1].GetComponent<CubeInfo>().GetRightForwardPosition().x, 0, segmentObjects[i - 1].GetComponent<CubeInfo>().GetRightForwardPosition().z);

                    correctPosition = rightPos - rightFrontPos;
                    segmentObjects[i].transform.position -= correctPosition;
                }

            }

            positionOfLastSegment = positionOfLastSegment + segmentObjects[i].transform.rotation * (new Vector3(0, 0, segments[i].length)) - correctPosition;

        }
        finishObject.position = positionOfLastSegment - new Vector3(0, 0.05f, 0) * segments.Count;
        finishObject.eulerAngles = eulerOfSegment;

    }


    private void OnValidate()
    {
        CheckCountOfSegments();
        SetWayProgress();
        ConfigurateCubes();
    }

    private void Start()
    {
        CheckCountOfSegments();
        SetWayProgress();
    }

}
