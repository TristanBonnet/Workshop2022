using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;
using GSGD2.Gameplay;
using GSGD2;

public class Trap : MonoBehaviour
{
    [SerializeField] DamageDealer _damageDealer = null;
    [SerializeField] bool _isActive = false;
    [SerializeField] Animator _animator = null;
    [SerializeField] Material UnactiveMaterial = null;
    [SerializeField] float _maxTimeReactive = 5f;
    [SerializeField] GameObject _triggerActivation = null;
    [SerializeField] AudioSource _audioSource = null;
    private float _currentTimeReactive = 0;
    private Material _startMaterial = null;
    private List<AIMovement> _currentAIMovementList = new List<AIMovement>();











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
            Renderer[] _list = GetComponentsInChildren<Renderer>();

            for (int i = 0; i < _list.Length; i++)
            {
                _list[i].material = UnactiveMaterial;
            }


        }

        else if (aIMovement != null)
        {

            Debug.Log("ADD AI");
            _currentAIMovementList.Add(aIMovement);


        }

        if (_projectile != null)
        {
            SetTrapActive(false);
            CheckCurrentAIMovement();
            Destroy(_projectile.gameObject);
            Debug.Log("PROJECTILE");
        }


        
        
    }

    private void OnTriggerExit(Collider other)
    {
        AIMovement aIMovement = other.GetComponentInParent<AIMovement>();


        if (aIMovement != null)
        {
            
            
            _currentAIMovementList.Remove(aIMovement);



        }






    }
    public void SetTrapActive(bool isActive)
    {
        CheckCurrentAIMovement();
        _audioSource.clip = LevelReferences.Instance.AudioManager.GetSound(14);
        _audioSource.Play();
        _isActive = isActive;
        _triggerActivation.SetActive(isActive);
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


    public void CheckCurrentAIMovement()
    {
        for (int i = 0; i < _currentAIMovementList.Count; i++)
        {
            Debug.Log("DESTROY");

            if (!_currentAIMovementList[i].IsDead)
            {
                _currentAIMovementList[i].SetIsDead(true);
                _currentAIMovementList.Remove(_currentAIMovementList[i]);
            }
            

        }



    }
}
