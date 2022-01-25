using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;
using GSGD2.Gameplay;

public class Trap : MonoBehaviour
{
    [SerializeField] DamageDealer _damageDealer = null;
    [SerializeField] bool _isActive = false;











    public bool IsActive => _isActive;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        // Check if player is enter 
        Damageable damageable = other.GetComponentInParent<Damageable>();

        if (damageable != null && _isActive)
        {
            // Give damages
            _damageDealer.GiveDamage(damageable);
            SetTrapActive(false);
        }

        else
        {
            Debug.Log("Don't find player");
        }
    }


    public void SetTrapActive(bool isActive)
    {
        _isActive = isActive;
        Debug.Log(isActive);

    }
}
