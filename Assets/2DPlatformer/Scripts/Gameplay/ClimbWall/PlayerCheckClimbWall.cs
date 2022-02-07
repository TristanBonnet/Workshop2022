using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2;
using GSGD2.Player;

public class PlayerCheckClimbWall : MonoBehaviour
{
    private CubeController _cubeController = null;
    private bool _canWallRun = false;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] Transform _startTransform = null;
    [SerializeField] float _distance = 5;
    [SerializeField] SpecialInput _specialInput = null;
    private bool _climb = false;
    [SerializeField] float _climbSpeed = 15f;
    [SerializeField] private bool _isActive = false;
    private ClimbWall _currentClimbWall = null;
    [SerializeField] private Transform _offSet = null;
    [SerializeField] private AudioSource _audioSource = null;
    private int currentIndexSound = 0;
    
    

    public bool IsActive => _isActive;
    public Transform Offset => _offSet;

    private void Start()
    {
        


        if (LevelReferences.Instance.PlayerReferences.TryGetCubeController(out CubeController cubeController))
        {
            _cubeController = cubeController;

        } 
    }


    private void FixedUpdate()
    {
        
            
            if (_cubeController.CurrentState == CubeController.State.WallGrab)
            {
            Debug.Log(_specialInput.LeftVerticalAxis);
                if (_specialInput.LeftVerticalAxis > 0)
                {
                   
                      if (_currentClimbWall.UpTransform.position.y > _offSet.position.y )
                      {
                         
                          Debug.Log("WALL GRAB");
                         _cubeController.Rigidbody.velocity = new Vector3(0, _specialInput.LeftVerticalAxis * _climbSpeed, 0);



                            if (!_audioSource.isPlaying && _cubeController.Rigidbody.velocity.y != 0)
                            {
                                  if (currentIndexSound == 0)
                                 {
                                    _audioSource.clip = LevelReferences.Instance.AudioManager.GetSound(10);
                                     currentIndexSound = 1;
                                    _audioSource.Play();
                                 }

                                 else
                                 {
                                   _audioSource.clip = LevelReferences.Instance.AudioManager.GetSound(11);
                                   currentIndexSound = 0;
                                    _audioSource.Play();
                                 }
                                 

                            }

                          

                      }


                     else
                     {

                         //_cubeController.transform.position = new Vector3(_cubeController.transform.position.x, _currentClimbWall.UpTransform.position.y, _cubeController.transform.position.z);
                          _cubeController.Rigidbody.velocity = Vector3.zero;
                          _audioSource.Stop();

                }

                
                }

               else
               {
                         if (_currentClimbWall.BottomTransform.position.y < _offSet.position.y)
                         {
                             _cubeController.Rigidbody.velocity = new Vector3(0, _specialInput.LeftVerticalAxis * _climbSpeed, 0);


                    if (!_audioSource.isPlaying && _cubeController.Rigidbody.velocity.y != 0)
                    {
                        if (currentIndexSound == 0)
                        {
                            _audioSource.clip = LevelReferences.Instance.AudioManager.GetSound(10);
                            _audioSource.Play();
                            currentIndexSound = 1;
                        }

                        else
                        {
                            _audioSource.clip = LevelReferences.Instance.AudioManager.GetSound(11);
                            _audioSource.Play();
                            currentIndexSound = 0;
                        }


                    }
                          }


                         else
                         {

                                   //_cubeController.transform.position = new Vector3(_cubeController.transform.position.x, _currentClimbWall.BottomTransform.position.y, _cubeController.transform.position.z);
                                   _cubeController.Rigidbody.velocity = Vector3.zero;

                           if (_audioSource.isPlaying)
                            {
                            _audioSource.Stop();

                           }
                         }

                          
                }

                //_cubeController.Rigidbody.velocity = new Vector3(0, _specialInput.LeftVerticalAxis * _climbSpeed, 0);

                //if (!CheckIfPlayerCanWallRun())
                //{
                    
                //    CheckCurrentState();

                //}


            }
        
       

        Debug.DrawLine(_startTransform.position,_startTransform.forward * _distance, Color.white);
        //Debug.Log(CheckIfPlayerCanWallRun());

    }



    public bool CheckIfPlayerCanWallRun()
    {
         Debug.DrawLine(_startTransform.position, _startTransform.position + _startTransform.forward * _distance, Color.white);


        if (Physics.Raycast(_startTransform.position,_startTransform.forward, out RaycastHit hit, _distance))
        {
           ClimbWall _climbWall =  hit.collider.GetComponentInParent<ClimbWall>();

            if (_climbWall != null)
            {

                _currentClimbWall = _climbWall;
                return true;

            }

            if (_climbWall == null)
            {

                _currentClimbWall = null;
                return false;

            }

        }

        else
        {
            _currentClimbWall = null;
            return false;
        }

        return false;

    }

    public void SetClimb(bool climb)
    {
        if (climb)
        {
            _cubeController.ChangeState(CubeController.State.WallGrab);
        }


        else
        {
            _cubeController.ChangeState(CubeController.State.Falling);
        }
    }

    public void CheckCurrentState()
    {
        if (_cubeController.CurrentState == CubeController.State.WallGrab)
        {

            SetClimb(false);

        }




    }

    public void SetActive(bool isActive)
    {

        _isActive = isActive;

    }
}
