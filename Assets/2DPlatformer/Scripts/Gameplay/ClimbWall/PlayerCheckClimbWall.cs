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





    private void Update()
    {
        Debug.Log(CheckIfPlayerCanWallRun());


    }



    private bool CheckIfPlayerCanWallRun()
    {
        Debug.DrawLine(_startTransform.position, _startTransform.position + _startTransform.forward * _distance, Color.white);


        if (Physics.Raycast(_startTransform.position, _startTransform.position +_startTransform.forward, out RaycastHit hit, _distance))
        {
           ClimbWall _climbWall =  hit.collider.GetComponentInParent<ClimbWall>();

            if (_climbWall != null)
            {

                return true;

            }

            if (_climbWall != null)
            {

                return false;

            }

        }

        else
        {
            Debug.Log("DONT TOUCH");
        }


        return false;
    }
}
