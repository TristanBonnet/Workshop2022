using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingPreview : MonoBehaviour
{
   
    [SerializeField] ThrowableLauncher _throwableLauncher = null;
    [SerializeField] LineRenderer _lineRenderer = null;

    public int numPoints = 50;
    public float timeBetweenPoints = 0.1f;

    private void Update()
    {
        _lineRenderer.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();

        Vector3 startingPosition = _throwableLauncher.transform.position;
        Vector3 startingVelocity = _throwableLauncher.transform.forward * _throwableLauncher.LaunchForce;

        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t -20f / 2f * t * t;
            points.Add(newPoint);

            

        }


        _lineRenderer.SetPositions(points.ToArray());
    }

}
