namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Utilities;

    public class SuperCubeAnimator : MonoBehaviour
    {
        [SerializeField]
        private PlayerReferences _playerReferences = null;
        [SerializeField]
        private float _endJumpDownwardSpeedThresholdWhenGrounded = 5f;

        [SerializeField]
        private AudioSource _audioSourceComponent = null;

        // Runtime
        private CubeController _cubeController = null;
        [SerializeField] private Animator _animator = null;
        private Rigidbody _rigibody = null;
        private DisplacementEstimationUpdater _displacementEstimationUpdater;
        private bool WallGrab = false;
        private bool isGrounded = false;

        private void Awake()
        {

            _playerReferences.TryGetCubeController(out _cubeController);
            //_playerReferences.TryGetAnimator(out _animator);
            _playerReferences.TryGetRigidbody(out _rigibody);
            _playerReferences.TryGetDisplacementEstimationUpdater(out _displacementEstimationUpdater);
           

            


        }

        private void OnEnable()
        {
            // je v�rifie que je suis bien d�branch� de l'�v�nement 
            _cubeController.StateChanged -= _cubeController_StateChanged;

            // je me branche � l'�v�nement 
            _cubeController.StateChanged += _cubeController_StateChanged;

        }

       

        private void OnDisable()
        {
            _cubeController.StateChanged -= _cubeController_StateChanged;
        }

        private void _cubeController_StateChanged(CubeController cubeController, CubeController.CubeControllerEventArgs args)
        {
            //Debug.Log("SUPER CUBE ANIMATOR STATE CHANGED");


            switch (args.currentState)
            {
                case CubeController.State.None:
                    break;
                case CubeController.State.Grounded:
                    { 
                    var downwardVelocityBelowThreshold = Vector3.Dot(_displacementEstimationUpdater.Velocity, -transform.up) > _endJumpDownwardSpeedThresholdWhenGrounded;
                    if (downwardVelocityBelowThreshold == true)
                    {
                            //PlayJump();
                            _animator.SetTrigger("EndJump");
                        }
                    }        
                     break;
                case CubeController.State.Falling:
                    {

                        _animator.SetBool("Fall", true);


                    }

                    break;
                case CubeController.State.Bumping:
                    break;
                case CubeController.State.StartJump:
                    {

                       

                        
                            
                    }



                    break;
                case CubeController.State.Jumping:
                    {
                        
                        _animator.SetTrigger("Jump");

                    }
                    break;
                case CubeController.State.EndJump:
                    {



                        



                    }


                    break;
                case CubeController.State.WallGrab:
                    {


                        _animator.SetTrigger("Grab");


                    }
                    break;
                case CubeController.State.WallJump:

                    {
                       _animator.SetTrigger("Jump");
                    }
                    break;
                case CubeController.State.Dashing:
                    {

                        _audioSourceComponent.clip = LevelReferences.Instance.AudioManager.GetSound(8);
                        _audioSourceComponent.Play();
                        _animator.SetTrigger("Dash");

                    }



                    break;
                case CubeController.State.DamageTaken:
                    break;
                case CubeController.State.Everything:
                    break;
                default:
                    break;
            }

            

            if (args.currentState != CubeController.State.Jumping)
            {
                _animator.SetBool("Jump", false);

            }

            if (args.currentState != CubeController.State.Falling)
            {
                _animator.SetBool("Fall", false);

            }



            //Debug.Log(args.currentState);
        }

        private void Update()
        {
            if (_cubeController.CurrentState == CubeController.State.WallGrab)
            {
                if (!WallGrab)
                {
                    WallGrab = true;
                    _animator.SetBool("WallGrab", WallGrab);
                }


                float YValue = Mathf.Abs(_rigibody.velocity.y);
                
                _animator.SetFloat("WallGrabState", YValue);


            }

            else
            {
                if (WallGrab)
                {
                    WallGrab = false;
                    _animator.SetBool("WallGrab", WallGrab);


                }


                float value = Mathf.Abs(_rigibody.velocity.z);

                _animator.SetFloat("IdleRunBlend", value);
            }

            if (_cubeController.IsGrounded && !isGrounded)
            {
                isGrounded = true;
                _animator.SetBool("IsGrounded", isGrounded);
            }

            else if (!_cubeController.IsGrounded && isGrounded)
            {
                isGrounded = false;
                _animator.SetBool("IsGrounded", isGrounded);
            }
        }

    }

}