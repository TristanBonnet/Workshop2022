using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowablePojectile : MonoBehaviour
{
    [SerializeField] float _projectileSpeed = 1f;
    [SerializeField] Rigidbody _rigibody = null;
    private Transform _target = null;

    [SerializeField] float h =  25f;
    [SerializeField] float gravity = -18f;

    [SerializeField] float _maxTime = 5f;

    private float _currentTime = 0f;

    private void Start()
    {

        //_rigibody.useGravity = false;

    }

    private void FixedUpdate()
    {
        //_rigibody.velocity = new Vector3(0, 0, _projectileSpeed);


    }


    public void Move()
    {
        Physics.gravity = Vector3.up * gravity;
        _rigibody.useGravity = true;
        _rigibody.velocity = CalculateLaunchVelocity();
    }

    Vector3 CalculateLaunchVelocity()
    {
        float displacementY = _target.position.y - _rigibody.transform.position.y;
        Vector3 displacementXZ = new Vector3 ( _target.transform.position.x - _rigibody.transform.position.x, 0, _target.transform.position.z - _rigibody.transform.position.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * h/ gravity) + Mathf.Sqrt(2*(displacementY - h)/gravity));

        return velocityXZ + velocityY;
    }


    public void SetTarget(Transform target)
    {

        _target = target;


    }
}


