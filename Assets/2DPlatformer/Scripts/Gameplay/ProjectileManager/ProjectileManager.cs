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





    private void Update()
    {

        _horizontalAxis += _specialInput.HorizontalAxis;

        Debug.DrawLine(_playerTransform.transform.position, _playerTransform.transform.position +  (_playerTransform.transform.forward * _horizontalAxis), Color.yellow);

        Debug.DrawLine(_playerTransform.transform.position + (_playerTransform.transform.forward * _horizontalAxis), _playerTransform.transform.position + (_playerTransform.transform.forward * _horizontalAxis) - _playerTransform.transform.up, Color.black);



        if (!Physics.Raycast(_playerTransform.transform.position, _playerTransform.transform.position + Vector3.forward, out RaycastHit hit, _horizontalAxis))
        {
            if (Physics.Raycast(_playerTransform.transform.position + Vector3.forward * _horizontalAxis, -_playerTransform.transform.up, out RaycastHit hitDown, _horizontalAxis))
            {
              _targetThrwoableProjectile.transform.position =  hitDown.transform.position;
            } 


        }

        else
        {
            _targetThrwoableProjectile.transform.position = hit.transform.position;
        }
       

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
        projectile.Move();
        Debug.Log("FIRE");


    }

}
