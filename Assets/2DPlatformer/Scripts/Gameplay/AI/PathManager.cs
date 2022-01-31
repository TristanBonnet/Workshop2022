using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] List<PathPoint> _listPathPoints = null;




    public List<PathPoint> PathPointsList => _listPathPoints;


    private void OnDrawGizmos()
    {
        for (int i = 0; i < _listPathPoints.Count; i++)
        {
            if (i != _listPathPoints.Count -1)
            {
                Debug.DrawLine(_listPathPoints[i].transform.position, _listPathPoints[i + 1].transform.position, Color.red);


            }

            else
            {
                Debug.DrawLine(_listPathPoints[i].transform.position, _listPathPoints[0].transform.position, Color.red);
            }
        }

    }
}
