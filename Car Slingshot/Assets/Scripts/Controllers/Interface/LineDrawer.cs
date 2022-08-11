using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField] Transform arrow;

    [SerializeField] float maxLineLength;

    private void ChangeLine(float power, float angle)
    {
        arrow.gameObject.SetActive(true);

        lineRenderer.positionCount = 2;

        lineRenderer.SetPosition(0, transform.position);

        Vector3 newPosition = new Vector3(power*maxLineLength,0,0);
        newPosition = Quaternion.Euler(0, angle, 0)*newPosition;
        lineRenderer.SetPosition(1, transform.position + newPosition);

        arrow.position = transform.position + newPosition;
        arrow.rotation = Quaternion.Euler(0, angle+90, 0);

        Color colorOfLine = lineRenderer.endColor;
        colorOfLine.a = power;

        arrow.GetChild(0).GetComponent<SpriteRenderer>().color = lineRenderer.startColor = lineRenderer.endColor = colorOfLine; 
    }

    private void HideLine()
    {
        lineRenderer.positionCount = 0;
        arrow.gameObject.SetActive(false);
    }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        EventManager.OnChangePower.AddListener(ChangeLine);
        EventManager.HideHelpers.AddListener(HideLine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
