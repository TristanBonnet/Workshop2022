using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GSGD2.Utilities;
using GSGD2.Player;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using GSGD2;

public class Pause : MonoBehaviour
{
   [SerializeField]


    private InputAction _PauseInteraction = null;
    [SerializeField] InputActionMapWrapper _inputActionWrapper = null;
    [SerializeField] GameObject _pauseUI = null;
    [SerializeField] EventSystem _eventSystem = null;
    [SerializeField] Button _focusedButton = null;
    private float _maxTimeDelay = 0.1f;
    private float currentTimeDelay = 0f;
    private bool activeDelay = false;


    private bool _isPaused = false;


    [SerializeField] string _inputToCheck = "Pause";

    private void OnEnable()
    {
        if (_inputActionWrapper.TryFindAction("Pause", out _PauseInteraction, true) == true)
        {
            _PauseInteraction.performed -= PauseAbility;
            _PauseInteraction.performed += PauseAbility;

        }
    }

    private void OnDisable()
    {
        _PauseInteraction.performed -= PauseAbility;
        _PauseInteraction.Disable();


    }


    private void PauseAbility(InputAction.CallbackContext obj)
    {

        if (_isPaused == true)
        {
            SetPauseActive(false);
            
        }


        else
        {
            SetPauseActive(true);
        }


    }


    public void SetPauseActive(bool active)

    {
        if (active)
        {
            _isPaused = true;
            EventSystem.current.SetSelectedGameObject(_focusedButton.gameObject);
            if (LevelReferences.Instance.PlayerReferences.TryGetCubeController(out CubeController cube))
            {

                cube.EnableJump(false);

            }  
            Time.timeScale = 0;
            _pauseUI.SetActive(true);
        }

        else
        {
            _isPaused = false;
            EventSystem.current.SetSelectedGameObject(null);
           
            Time.timeScale = 1;

            activeDelay = true;
            _pauseUI.SetActive(false);

        }

        

    }

    private void Update()
    {
        if (activeDelay)
        {
            if (currentTimeDelay < _maxTimeDelay)
            {
                currentTimeDelay += Time.deltaTime;
            }


            else
            {
                if (LevelReferences.Instance.PlayerReferences.TryGetCubeController(out CubeController cube))
                {

                    cube.EnableJump(true);

                }


                activeDelay = false;
                currentTimeDelay = 0;




            }

        }

       
    }
}
