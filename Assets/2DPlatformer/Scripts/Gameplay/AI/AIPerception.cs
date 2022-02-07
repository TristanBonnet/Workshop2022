
// Reference : https://www.youtube.com/watch?v=rQG9aUWarwE 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2;
using GSGD2.Player;

public class AIPerception : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngles;
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();

    private void Start()
    {
        StartCoroutine("FindTargetsWithDelay", 0.2f);
    }



    IEnumerator FindTargetsWithDelay(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();

        }


    }


    private void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            PlayerController _player = targetsInViewRadius[i].GetComponentInParent<PlayerController>();
            if (_player != null)
            {
                Transform target = targetsInViewRadius[i].transform;
                Vector3 dirToTarget = (target.transform.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngles / 2)
                {
                    float disToTarget = Vector3.Distance(transform.position, target.transform.position);
                    if (!Physics.Raycast(transform.position, dirToTarget, disToTarget, obstacleMask))
                    {
                        visibleTargets.Add(target);
                    }
                }


            }
            


        }

    }
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        //return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        return new Vector3(0, Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }


    public bool CheckSeePlayer()
    {

        if (visibleTargets.Count > 0)
        {
            return true;
        }

        else
        {
            return false;
        }

    }
}
