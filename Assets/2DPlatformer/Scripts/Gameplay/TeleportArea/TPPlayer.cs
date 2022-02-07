using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPlayer : MonoBehaviour
{
    private bool isInTPArea = false;
    private TeleportArea _currentTeleportArea = null;
    private bool _startTimer = false;
    private float _currentTPTime;


    public bool IsInArea => isInTPArea;

    public TeleportArea CurrentTeleportArea => _currentTeleportArea;

    private void Update()
    {
        if (_startTimer)
        {
            if (_currentTPTime < 1.5f)            {

                _currentTPTime += Time.deltaTime;

            }



            else
            {

                TeleportArea();
                
            }
        }


    }
    public void SetIsInArea(bool isActive)
    {


        isInTPArea = isActive;

    }

    public void TeleportArea()
    {
        if (_currentTeleportArea != null)
        {
            transform.position = _currentTeleportArea.TPArea.transform.position;
        }
        
        StartTimer(false);


    }


    public void StartTimer(bool start)
    {
        _startTimer = start;
        _currentTPTime = 0;


    }

    public void SetCurrentTPArea(TeleportArea TPArea)
    {

        _currentTeleportArea = TPArea;



    }
}
