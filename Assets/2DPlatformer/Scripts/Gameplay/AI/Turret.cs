using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2;
using GSGD2.Player;
using UnityEngine.Events;
using GSGD2.Gameplay;


public class Turret : MonoBehaviour
{
    [SerializeField] float _delayBetweenBullet = 0.1f;
    [SerializeField] float _delayDuringFire = 2f;
    [SerializeField] int _projectileNumber = 1;
    [SerializeField] ProjectileTurret _projectileTurret = null;
    [SerializeField] Vector3 _projectileScale = new Vector3(1, 1, 1);
    [SerializeField] Transform _offset = null;
    [SerializeField] PhysicsTriggerEvent _triggerEvent = null;
    [SerializeField] Animator _animator = null;

    private float _currentTimeBetweenBullet = 0;
    private float _currentDuringFire = 0;
    private int _currentProjectileSpawn = 0;

    private bool _activeTurret = false;
    private bool _playerInRange = false;

    [SerializeField] GameObject _head = null;

    private PlayerReferences _player = null;

    private List<Transform> _playerPosition = null;

    [SerializeField] float maxTimeFollowPlayer = 0.2f;
    private float currentTimeFollowPlayer = 0;

    [SerializeField] float delayRotation = 1f;

    enum State
    {
        Wait,
        Fire

    }

    private State turretState = State.Wait;

    private void Awake()
    {
       _player =  LevelReferences.Instance.PlayerReferences;
    }

    private void Update()
    {
        //if (_playerPosition.Count > 20)
        //{

        //    LookPlayer(_playerPosition[0]);
        //    _playerPosition.RemoveAt(0);
        //    _playerPosition.Add(_player.transform);

        //}

        if (_playerInRange)
        {
            CheckPlayer();
            Debug.Log("InRange");
        }

        if (_activeTurret == true)
        {
            LookPlayer(_player.transform);


            switch (turretState)
            {
                case State.Wait:
                    {
                        if (_currentDuringFire < _delayDuringFire)
                        {
                            _currentDuringFire += Time.deltaTime;
                        }

                        else
                        {
                            ResetCurrentTimeDuringFire();
                            SwitchState(State.Fire);
                        }
                    }

                    break;
                case State.Fire:
                    {
                        if (_currentProjectileSpawn < _projectileNumber)
                        {
                            if (_currentTimeBetweenBullet < _delayBetweenBullet)
                            {
                                _currentTimeBetweenBullet += Time.deltaTime;
                            }

                            else
                            {
                                _animator.SetTrigger("Fire");
                                ResetCurrentTimeBetweenBullet();
                                Fire();
                                _currentProjectileSpawn += 1;
                            }
                        }

                        else
                        {
                            SwitchState(State.Wait);
                            _currentProjectileSpawn = 0;
                        }

                    }
                    break;
                default:
                    break;
            }

        }
       

    }

    private void LookPlayer(Transform target)
    {

        //_head.transform.LookAt(transform);
         Quaternion newRotation = Quaternion.LookRotation(target.position - _head.transform.position, Vector3.right);
        _head.transform.rotation = Quaternion.Slerp(_head.transform.rotation, newRotation, Time.deltaTime * delayRotation);
    }
    
    private void SwitchState(State state)
    {

        turretState = state;

    }

   private void ResetCurrentTimeDuringFire()
    {
        _currentDuringFire = 0;
    }

    private void ResetCurrentTimeBetweenBullet()
    {
        _currentTimeBetweenBullet = 0;

    }

    private void Fire()
    {

        ProjectileTurret _currentProjectile = Instantiate<ProjectileTurret>(_projectileTurret);
        _currentProjectile.transform.localScale = _projectileScale;
        _currentProjectile.transform.position = _offset.transform.position;
        _currentProjectile.transform.rotation = _offset.transform.rotation;

    }

    private void SetActiveTurret(bool active)
    {
        _activeTurret = active;
    }

    private void CheckPlayer()
    {
      float distance = Vector3.Distance(transform.position, _player.transform.position);

        if (Physics.Raycast(transform.position, _player.transform.position, distance))
        {
            if (_activeTurret)
            {
                _activeTurret = false;
            }

           
        }

        else
        {
            if (_activeTurret == false)
            {

                _activeTurret = true;

            }


        }
    }

    public void SetPlayerInRange(bool inRange)
    {

        _playerInRange = inRange;



    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();


            if(player != null)
            {

               SetPlayerInRange(true);

            }

        else
        {
            Debug.Log("NOT PLAYER");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        CubeController player = other.GetComponentInParent<CubeController>();


        if (player != null)
        {

            SetPlayerInRange(false);
            ResetCurrentTimeBetweenBullet();
            ResetCurrentTimeDuringFire();
            SetActiveTurret(false);
            SwitchState(State.Wait);

        }


    }
}
