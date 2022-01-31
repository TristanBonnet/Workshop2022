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
    [SerializeField] float _maxTimeReactive = 5f;
    private float _currentTimeReactive = 0;
    private Material _startMaterial = null;











    public bool IsActive => _isActive;


    private void Start()
    {
        Renderer _renderer = GetComponentInChildren<Renderer>();
       _startMaterial = _renderer.material;
        
    }

    private void Update()
    {
        if (!_isActive)
        {
            if (_currentTimeReactive < _maxTimeReactive)
            {
                _currentTimeReactive += Time.deltaTime;

            }

            else
            {
                SetTrapActive(true);
                _currentTimeReactive = 0;
            }

        }


        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        // Check if player is enter 
        Damageable damageable = other.GetComponentInParent<Damageable>();
        ThrowableNewTest _projectile = other.GetComponentInParent<ThrowableNewTest>();
        AIMovement aIMovement = other.GetComponentInParent<AIMovement>();

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
            
            Destroy(_projectile.gameObject);
        }


        else if (aIMovement != null)
        {
            SetTrapActive(false);

            Destroy(aIMovement.gameObject);


        }
        
    }


    public void SetTrapActive(bool isActive)
    {
        _isActive = isActive;
        Debug.Log(isActive);
        Renderer[] _list = GetComponentsInChildren<Renderer>();

        if (_isActive)
        {
            
            for (int i = 0; i < _list.Length; i++)
            {
                _list[i].material = _startMaterial;
            }


        }


        else
        {
            for (int i = 0; i < _list.Length; i++)
            {
                _list[i].material = UnactiveMaterial;
            }
        }

    }
}
