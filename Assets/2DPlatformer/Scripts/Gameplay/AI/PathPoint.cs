using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    [SerializeField] private float _waitingTime = 0;


    public float WaitingTime => _waitingTime;
}
