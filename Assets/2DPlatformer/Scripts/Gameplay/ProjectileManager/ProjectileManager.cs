using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] int _maxProjectileNumber = 5;
    [SerializeField] int _currentProjectileCount = 2;




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


        Debug.Log("FIRE");


    }

}
