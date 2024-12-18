using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracePlayerPath : MonoBehaviour
{
    private GameObject Kayak;
    private Vector3 lastPosition;
    private Vector3 newPosition;
    public float totalDistance = 0f;
    private LineRenderer lineRenderer;
    private List<Vector3> linePositions = new List<Vector3>();

    private void Start()
    {
        StartCoroutine(WaitForKayakInitialization());

        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {

            return;
        }
    }

    private IEnumerator WaitForKayakInitialization()
    {
        while (Kayak == null)
        {
            Kayak = GameObject.FindGameObjectWithTag("kayak"); 
            yield return null; 
        }

        lastPosition = Kayak.transform.position;
        StartCoroutine(TrackKayakPosition());
    }

    private IEnumerator TrackKayakPosition()
    {
        while (true)
        {
            if (Kayak != null)
            {
                newPosition = Kayak.transform.position;

                linePositions.Add(lastPosition);
                linePositions.Add(newPosition);

                UpdateLineRenderer();



                float distanceMoved = Vector3.Distance(lastPosition, newPosition);
                //Debug.Log("Distance moved in last 3 seconds: " + distanceMoved);
                totalDistance += distanceMoved;
                lastPosition = newPosition;
            }

            yield return new WaitForSeconds(1.5f);
        }
    }

    private void UpdateLineRenderer()
    {
        lineRenderer.positionCount = linePositions.Count;

        for (int i = 0; i < linePositions.Count; i++)
        {
            lineRenderer.SetPosition(i, linePositions[i]);
        }
    }
}
