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

    public bool IsActive => _isActive;

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


                _cubeController.Rigidbody.velocity = new Vector3(0, _specialInput.LeftVerticalAxis * _climbSpeed, 0);
                if (!CheckIfPlayerCanWallRun())
                {

                    CheckCurrentState();

                }


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

                return true;

            }

            if (_climbWall == null)
            {

                return false;

            }

        }

        else
        {
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
