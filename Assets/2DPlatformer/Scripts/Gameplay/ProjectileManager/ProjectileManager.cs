using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] int _maxProjectileNumber = 5;
    [SerializeField] int _currentProjectileCount = 2;
    [SerializeField] Transform _playerTransform = null;
    [SerializeField] Transform _startPoint = null;
    [SerializeField] Transform _targetThrwoableProjectile = null;
    [SerializeField] Transform _traceTransformProjectile = null;
    [SerializeField] float _horizontalAxis = 0;
    [SerializeField] ThrowablePojectile _projectile = null;
    [SerializeField] SpecialInput _specialInput = null;
    [SerializeField] float _targetMoveSpeed = 1f;
    [SerializeField] Transform _refTransform = null;
    [SerializeField] float _maxDistanceThrowable = 10f;
    [SerializeField] float _height = 5f;
    [SerializeField] float _gravity = -20f;
    [SerializeField] ThrowablePreview _throwablePreview = null;
    private float _lastHorizontalAxis = 0f;
    private Vector3 _lastPosition =  new Vector3(0,0,0);


    


    private void Update()
    {
        if (_lastHorizontalAxis != _horizontalAxis || _refTransform.position != _lastPosition)
        {
            ThrowablePreview projectile = Instantiate<ThrowablePreview>(_throwablePreview);

            projectile.SetTarget(_targetThrwoableProjectile);
            projectile.transform.position = _startPoint.transform.position;
            projectile.transform.rotation = _startPoint.transform.rotation;
            projectile.Move(_gravity, CalculateLaunchData().initialVelocity);
        }

        _horizontalAxis += _specialInput.HorizontalAxis * Time.deltaTime * _targetMoveSpeed;

        
       

        if (_horizontalAxis < 0)
        {
            _horizontalAxis = 0;
        }

        else if (_horizontalAxis > _maxDistanceThrowable)
        {

            _horizontalAxis = _maxDistanceThrowable;

        }

        Vector3 firstTraceEndPostion = _playerTransform.transform.position + (_playerTransform.transform.forward * _horizontalAxis);
        Vector3 secondTraceEndPosition = _playerTransform.transform.position + (_playerTransform.transform.forward * _horizontalAxis) - _playerTransform.transform.up * 500;

        if (_refTransform.rotation.y > 90)
        {
             firstTraceEndPostion = _playerTransform.transform.position + (_playerTransform.transform.forward * -_horizontalAxis);
             secondTraceEndPosition = _playerTransform.transform.position + (_playerTransform.transform.forward * -_horizontalAxis) - _playerTransform.transform.up * 500;
        }

        Debug.DrawLine(_playerTransform.transform.position,firstTraceEndPostion, Color.yellow);
        Debug.DrawLine(firstTraceEndPostion, secondTraceEndPosition, Color.black);



        if (!Physics.Raycast(_playerTransform.transform.position, firstTraceEndPostion, out RaycastHit hit, _horizontalAxis))
        {
            if (Physics.Raycast(firstTraceEndPostion, secondTraceEndPosition, out RaycastHit hitDown, 500))
            {
              _targetThrwoableProjectile.transform.position =  hitDown.point;
                Debug.Log(hitDown.transform.position);
            } 


        }

        else
        {
            Physics.Raycast(firstTraceEndPostion, secondTraceEndPosition, out RaycastHit hitDown, 500);
            Vector3 upDirection = hit.point * _height;
            if (!Physics.Raycast(upDirection, upDirection + _refTransform.forward))
            {

                _targetThrwoableProjectile.transform.position = hitDown.point;
                Debug.Log(hitDown.transform.position);

            }

            else
            {
                _targetThrwoableProjectile.transform.position = hit.point;
            }
            

        }


        _lastHorizontalAxis = _horizontalAxis;
        _lastPosition = _refTransform.transform.position;

    }
    public bool CheckProjectileCountIsSuperiorThan0()
    {
       return _currentProjectileCount > 0;

    }

    public bool CheckProjectileCountIsInferiorThanMax()
    {
        return _currentProjectileCount < _maxProjectileNumber;

    }

    public void AddProjectile(int numnberOfProjectile)
    {
        _currentProjectileCount += numnberOfProjectile;

        if (!CheckProjectileCountIsInferiorThanMax())
        {
            _currentProjectileCount = _maxProjectileNumber;
        }

    }


    public void RemoveProjectile(int numberToRemove)
    {

        _currentProjectileCount -= numberToRemove;

        if (!CheckProjectileCountIsSuperiorThan0())
        {
            _currentProjectileCount = 0;
        }

    }

    public void Fire()
    {

        ThrowablePojectile projectile = Instantiate<ThrowablePojectile>(_projectile);

        projectile.SetTarget(_targetThrwoableProjectile);
        projectile.transform.position = _startPoint.transform.position;
        projectile.transform.rotation = _startPoint.transform.rotation;
        projectile.Move(_gravity, CalculateLaunchData().initialVelocity);
        Debug.Log("FIRE");


    }

    LaunchData CalculateLaunchData()
    {
        float displacementY = _targetThrwoableProjectile.position.y - _startPoint.position.y;
        Vector3 displacementXZ = new Vector3(_targetThrwoableProjectile.transform.position.x - _startPoint.position.x, 0, _targetThrwoableProjectile.transform.position.z - _startPoint.position.z);
        float time = Mathf.Sqrt(-2 * _height / _gravity) + Mathf.Sqrt(2 * (displacementY - _height) / _gravity);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * _gravity * _height);
        Vector3 velocityXZ = displacementXZ / time;

        return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(_gravity), time);
    }


    struct LaunchData
    {
        public readonly Vector3 initialVelocity;
        public readonly float timeToTarget;

        public LaunchData(Vector3 initialVelocity, float timeToTarget)
        {
            this.initialVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;
        }
    }

}
