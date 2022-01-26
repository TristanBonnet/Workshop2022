using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowablePreview : MonoBehaviour
{
    [SerializeField] float _projectileSpeed = 1f;
    [SerializeField] Rigidbody _rigibody = null;
    private Transform _target = null;

    [SerializeField] float h =  25f;
    [SerializeField] float gravity = -18f;
    [SerializeField] MeshRenderer _mesh = null;
    private List<MeshRenderer> _listMeshRenderer =  new List<MeshRenderer>(0);

    [SerializeField] float _maxTime = 5f;

    private float _currentTime = 0f;

    private void Start()
    {

        //_rigibody.useGravity = false;

    }

    private void Update()
    {
        DrawSphere();

        MeshRenderer mesh = Instantiate<MeshRenderer>(_mesh);
        mesh.transform.position = transform.position;
        _listMeshRenderer.Add(mesh);

    }                      

   
    public void Move(float gravity, Vector3 launchVelocity  )
    {
        Physics.gravity = Vector3.up * gravity;
        _rigibody.useGravity = true;
        _rigibody.velocity = launchVelocity;
    }

    LaunchData CalculateLaunchData()
    {
        float displacementY = _target.position.y - _rigibody.transform.position.y;
        Vector3 displacementXZ = new Vector3 ( _target.transform.position.x - _rigibody.transform.position.x, 0, _target.transform.position.z - _rigibody.transform.position.z);
        float time = Mathf.Sqrt(-2*h/gravity) + Mathf.Sqrt(2*(displacementY - h) / gravity);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementXZ / time;

        return new LaunchData (velocityXZ + velocityY * -Mathf.Sign(gravity), time);
    }


    struct LaunchData
    {
        public readonly Vector3 initialVelocity;
        public readonly float timeToTarget;

        public  LaunchData (Vector3 initialVelocity, float timeToTarget)
        {
            this.initialVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;
        }
    }


    void DrawSphere()
    {
        LaunchData launchData = CalculateLaunchData();
        Vector3 previousDrawSphere = _rigibody.transform.position;

        int resolution = 30;

        for (int i = 1; i < resolution; i++)
        {
            float simulationTime = i / (float)resolution * launchData.timeToTarget;
            Vector3 displacement = launchData.initialVelocity * (simulationTime + gravity * simulationTime * simulationTime / 2f);
            Vector3 drawSphere = _rigibody.transform.position + displacement;

            Debug.DrawLine(previousDrawSphere, drawSphere, Color.green);

            previousDrawSphere = drawSphere;
        }

    }

    public void SetTarget(Transform target)
    {

        _target = target;


    }
}


