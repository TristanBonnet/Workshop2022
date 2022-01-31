using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (AIPerception))]
public class AIPerceptionEditor : Editor
{
   


   private void OnSceneGUI()
    {
        AIPerception _perception = (AIPerception)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(_perception.transform.position, Vector3.right, Vector3.forward, 360, _perception.viewRadius);
        Vector3 viewAngleA = _perception.DirFromAngle(-_perception.viewAngles / 2, false);
        Vector3 viewAngleB = _perception.DirFromAngle(_perception.viewAngles / 2, false);

        Handles.DrawLine(_perception.transform.position, _perception.transform.position + viewAngleA * _perception.viewRadius);
        Handles.DrawLine(_perception.transform.position, _perception.transform.position + viewAngleB * _perception.viewRadius);


        Handles.color = Color.black;
        foreach(Transform visibleTarget in _perception.visibleTargets)
        {
            Handles.DrawLine(_perception.transform.position, visibleTarget.transform.position);



        }

    }



   
}
