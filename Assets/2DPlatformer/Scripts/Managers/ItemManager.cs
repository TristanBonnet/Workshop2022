using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2;

public class ItemManager : MonoBehaviour
{
    [SerializeField] int _maxProjectileNumber = 5;
    [SerializeField] int _currentProjectileCount = 1;

    [SerializeField] ThrowableLauncher _throwableLauncher = null;

    [SerializeField] Animator _animator = null;


    private void Start()
    {
        LevelReferences.Instance.UIManager.UpdatePebbleText(0, _currentProjectileCount.ToString());
        LevelReferences.Instance.UIManager.UpdatePebbleText(1, _maxProjectileNumber.ToString());
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

        LevelReferences.Instance.UIManager.UpdatePebbleText(0, _currentProjectileCount.ToString());
    }


    public void RemoveProjectile(int numberToRemove)
    {

        _currentProjectileCount -= numberToRemove;

        if (!CheckProjectileCountIsSuperiorThan0())
        {
            _currentProjectileCount = 0;
        }

        LevelReferences.Instance.UIManager.UpdatePebbleText(0, _currentProjectileCount.ToString());
    }

    public void Fire()
    {
        if (CheckProjectileCountIsSuperiorThan0())
        {
            
            _throwableLauncher.Fire();
            RemoveProjectile(1);
            


        } 



    }


    public void AddMaxProjectileCount(int numberToAdd)
    {

        _maxProjectileNumber += numberToAdd;

        LevelReferences.Instance.UIManager.UpdatePebbleText(1, _maxProjectileNumber.ToString());


    }
}
