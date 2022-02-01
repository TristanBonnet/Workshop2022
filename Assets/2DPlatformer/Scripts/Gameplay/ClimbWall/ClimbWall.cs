using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbWall : MonoBehaviour
{
    [SerializeField] Transform _upTransform = null;
    [SerializeField] Transform _bottomTransform = null;

    public Transform UpTransform => _upTransform;
    public Transform BottomTransform => _bottomTransform;

    private void Start()
    {
       
    }
}
