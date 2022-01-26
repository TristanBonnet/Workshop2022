using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;
using GSGD2.Gameplay;

public class Trap : MonoBehaviour
{
    [SerializeField] DamageDealer _damageDealer = null;
    [SerializeField] bool _isActive = false;
    [SerializeField] Animator _animator = null;
    [SerializeField] Material UnactiveMaterial = null;











    public bool IsActive => _isActive;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        // Check if player is enter 
        Damageable damageable = other.GetComponentInParent<Damageable>();
        ThrowableNewTest _projectile = other.GetComponentInParent<ThrowableNewTest>();

        if (damageable != null && _isActive)
        {
            // Give damages
            _damageDealer.GiveDamage(damageable);
            SetTrapActive(false);
           Renderer[] _list =  GetComponentsInChildren<Renderer>();

            for (int i = 0; i < _list.Length; i++)
            {
                _list[i].material = UnactiveMaterial; 
            }
        }

        
        else if (_projectile != null && _isActive)
        {
            SetTrapActive(false);
            Renderer[] _list = GetComponentsInChildren<Renderer>();
            for (int i = 0; i < _list.Length; i++)
            {
                _list[i].material = UnactiveMaterial;
            }

            Destroy(_projectile.gameObject);
        }
        
    }


    public void SetTrapActive(bool isActive)
    {
        _isActive = isActive;
        Debug.Log(isActive);

    }
}
