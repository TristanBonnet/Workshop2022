using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2;
using GSGD2.Player;

public class AIMovement : MonoBehaviour
{
    [SerializeField] float _speed = 20f;
    [SerializeField] bool isStatic = true;
    [SerializeField] bool _loop = true;
    [SerializeField] PathManager _pathManager = null;
    [SerializeField] float _destinationThreshold = 0.2f;
    [SerializeField] bool _startActive = true;
    [SerializeField] float _timeBeforeMoveToNoiseLocation = 0.5f;
    [SerializeField] float _timeWaitingAtNoiseLocation = 3f;
    [SerializeField] Rigidbody _rigibody = null;
    [SerializeField] Transform _range = null;
    [SerializeField] Transform _rangePointRight = null;
    [SerializeField] Transform _rangePointLeft = null;
    [SerializeField] AIPerception _aIPerception = null;
    [SerializeField] float _delayBetweenFire = 1f;
    [SerializeField] Transform _startPointProjectile = null;
    [SerializeField] AIProjectile _aiProjectile = null;
    private bool _seePlayer = false;
    private PlayerController _player = null;
    private float _currentTimeBewteenFire = 0;
    private float _timeEarSomething = 2f;
    private float _currentTimeEarSomething = 0;
    private PathPoint _currentPathPoint = null;
    private int _currentIndex = 0;
    private float _currentWaitingTime = 0;
    //private Rigidbody _rigibody = null;
    private float _distanceDestination = 0;
    private float _speedFactor = 1f;
    private Vector3 _noiseLocation;
    private float _currentTimeBeforeMoveToNoiseLocation = 0;
    private float _currentTimeWaitingAtNoiseLocation = 0;
    private float AIRange = 0;
    private Vector3 startPosition;
    



    public enum State
    {
        Patroling,
        Attacking,
        Waiting, 
        Eard

    }

    private State _currentState = State.Patroling;
    private State _lastState = State.Waiting;

    public State CurrentState => _currentState;

    private void Start()
    {
        if (LevelReferences.Instance.PlayerReferences.TryGetPlayerController(out PlayerController player))
        {

            _player = player;

        }
        
        if (!isStatic)
        {
            _range.DetachChildren();
            _currentPathPoint = _pathManager.PathPointsList[0];
            LookPathPoint();
            
            Debug.Log(_rangePointLeft.transform.position);
            Debug.Log( _rangePointRight.transform.position);

           
            startPosition = transform.position;
            AIRange = Vector3.Distance(_rangePointLeft.position, _rangePointRight.position);
            
        }
        

            
    }

    private void OnDrawGizmos()
    {
        Color _color = Color.yellow;
        Debug.DrawLine(_rangePointLeft.transform.position, _rangePointRight.transform.position, _color);
    }

    private void Update()
    {
        //Debug.Log(_currentState);
        if (_startActive)
        {
            if (_aIPerception.CheckSeePlayer())
            {
                if (!_seePlayer)
                {
                    ChangeLastState(_currentState);
                    ChangeState(State.Attacking);
                    Fire();
                    _seePlayer = true;
                }
               

            }

            else
            {
                if (_seePlayer)
                {
                    ChangeLastState(_currentState);
                    ChangeState(State.Patroling);
                    _seePlayer = false;

                    if (_currentTimeBewteenFire != 0)
                    {
                        _currentTimeBewteenFire = 0;
                    }
                }
                

            }


            if (!isStatic)
            {
                 
                switch (_currentState)
                {
                    case State.Patroling:
                        {
                            float distanceDestination = Vector3.Distance(transform.position, _currentPathPoint.transform.position);
                            if (CheckPlayerInRange())
                            {
                               
                                if (distanceDestination > _destinationThreshold)
                                {
                                    transform.position += (_currentPathPoint.transform.position - transform.position).normalized * _speed * Time.deltaTime;
                                    //_rigibody.velocity = (_currentPathPoint.transform.position - transform.position).normalized * _speed * Time.deltaTime;
                                }

                                else
                                {
                                    Debug.Log("CHANGE STATE");
                                    ChangeLastState(_currentState);
                                    ChangeState(AIMovement.State.Waiting);
                                }


                            }

                            else
                            {
                                if (!OutRangeLeft())
                                {
                                    transform.position -= new Vector3(0,0,0.1f);
                                    ChangeLastState(_currentState);
                                    ChangeState(AIMovement.State.Waiting);
                                }

                                else
                                {
                                    transform.position += new Vector3(0, 0, 0.1f);
                                    ChangeLastState(_currentState);
                                    ChangeState(AIMovement.State.Waiting);
                                }
                                

                            }
                            

                        }

                        break;

                    case State.Attacking:
                        {
                            _startPointProjectile.rotation = Quaternion.LookRotation(_player.transform.position - transform.position);
                            if (_currentTimeBewteenFire <  _delayBetweenFire)
                            {
                                _currentTimeBewteenFire += Time.deltaTime;
                            }

                            else
                            {
                                Fire();
                                _currentTimeBewteenFire = 0;
                            }


                           


                        }
                        break;
                    case State.Waiting:
                        {
                            if (_currentWaitingTime < _currentPathPoint.WaitingTime)
                            {
                                
                                _currentWaitingTime += Time.deltaTime;


                            }

                            else
                            {
                                
                                ResetCurrentWaitingTime();
                                ChangeLastState(_currentState);
                                GetNextPathPoint();
                                ChangeState(State.Patroling);



                            }


                        }
                        break;

                    case State.Eard:
                        {
                            if (_currentTimeBeforeMoveToNoiseLocation < _timeBeforeMoveToNoiseLocation)
                            {

                                _currentTimeBeforeMoveToNoiseLocation += Time.deltaTime;


                            }

                            else
                            {
                                if (transform.rotation != LookNoise())
                                {
                                    LookNoise();
                                }


                                Vector3 targetLocation = new Vector3(transform.position.x, transform.position.y, _noiseLocation.z);
                                float distanceNoiseLocation = Vector3.Distance(transform.position, targetLocation);
                                if (CheckPlayerInRange())
                                {
                                    if (distanceNoiseLocation > _destinationThreshold)
                                    {

                                        transform.position += (targetLocation - transform.position).normalized * _speed * Time.deltaTime;
                                        //_rigibody.velocity = (targetLocation - transform.position).normalized * _speed * Time.deltaTime; ;
                                    }

                                    else
                                    {
                                        if (_currentTimeWaitingAtNoiseLocation < _timeWaitingAtNoiseLocation)
                                        {
                                            _currentTimeWaitingAtNoiseLocation += Time.deltaTime;
                                        }

                                        else
                                        {
                                            
                                            _noiseLocation = Vector3.zero;
                                            LookPathPoint();
                                            ChangeState(State.Patroling);
                                            _currentTimeBeforeMoveToNoiseLocation = 0;
                                            _currentTimeWaitingAtNoiseLocation = 0;


                                        }

                                    }


                                }

                                else
                                {
                                    if (!OutRangeLeft())
                                    {
                                        

                                        if (_currentTimeWaitingAtNoiseLocation < _timeWaitingAtNoiseLocation)
                                        {
                                            _currentTimeWaitingAtNoiseLocation += Time.deltaTime;
                                        }

                                        else
                                        {
                                            transform.position -= new Vector3(0, 0, 0.1f);
                                            _noiseLocation = Vector3.zero;
                                            LookPathPoint();
                                            ChangeState(State.Patroling);
                                            _currentTimeBeforeMoveToNoiseLocation = 0;
                                            _currentTimeWaitingAtNoiseLocation = 0;


                                        }
                                    }

                                    else
                                    {
                                        
                                        if (_currentTimeWaitingAtNoiseLocation < _timeWaitingAtNoiseLocation)
                                        {
                                            _currentTimeWaitingAtNoiseLocation += Time.deltaTime;
                                        }

                                        else
                                        {
                                             transform.position += new Vector3(0, 0, 0.1f);
                                             _noiseLocation = Vector3.zero;
                                            LookPathPoint();
                                            ChangeState(State.Patroling);
                                            _currentTimeBeforeMoveToNoiseLocation = 0;
                                            _currentTimeWaitingAtNoiseLocation = 0;


                                        }
                                    }
                                    
                                    



                                }
                            }



                        }
                        break;
                    default:
                        break;
                }








            }

        }






    }


    private void FixedUpdate()
    {
        
    }

    private void GetNextPathPoint()
    {
        if (_currentIndex < _pathManager.PathPointsList.Count - 1)
        {
            _currentIndex += 1;

            _currentPathPoint = _pathManager.PathPointsList[_currentIndex];


        }

        else
        {
            _currentIndex = 0;
            _currentPathPoint = _pathManager.PathPointsList[_currentIndex];
        }

        LookPathPoint();
        
    }

    public void ChangeState(State newState)
    {
        
        _currentState = newState;




    }

    public void ChangeLastState(State newState)
    {

        _lastState = newState;

    }

    private void ResetCurrentWaitingTime()
    {

        _currentWaitingTime = 0;

    }

    private void ResetCurrentWEarSomethingTime()
    {

        _currentTimeEarSomething = 0;

    }


    private void LookPathPoint()
    {

        Quaternion newRotation = Quaternion.LookRotation(_currentPathPoint.transform.position - transform.position, Vector3.up);
        transform.rotation = newRotation;
       //Quaternion.Euler(transform.rotation.x, transform.rotation.y, newRotation.z);

    }

    private Quaternion LookNoise()
    {
        Vector3 targetLocation = new Vector3(transform.position.x, transform.position.y, _noiseLocation.z);
        Quaternion newRotation = Quaternion.LookRotation(targetLocation - transform.position, Vector3.up);
        transform.rotation = newRotation;
        return newRotation;

    }


    public void ActiveAI()
    {

        _startActive = true;
 
    }

    public void SetNoiseLocation(Vector3 noiseLocation)
    {
        if (_currentState != State.Attacking)
        {
            _currentTimeBeforeMoveToNoiseLocation = 0;
            _currentTimeWaitingAtNoiseLocation = 0;
            ResetCurrentWEarSomethingTime();
            _noiseLocation = noiseLocation;
            //LookNoise();
            ChangeLastState(_currentState);
            ChangeState(State.Eard);

           

        }

        

    }

    public bool CheckPlayerInRange()
    {
        if (_rangePointLeft.transform.position.z < transform.position.z && transform.position.z < _rangePointRight.position.z)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public bool OutRangeLeft()
    {
        if (_rangePointLeft.transform.position.z > transform.position.z )
        {
            return true;
        }

        else if (_rangePointRight.position.z < transform.position.z)
        {
            return false;
        }

        return false;

    }


    private void Fire()
    {

        Instantiate(_aiProjectile, _startPointProjectile.transform.position, _startPointProjectile.transform.rotation);


    }
}
