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
    [SerializeField] private CapacityMenu _capacityMenu = null;
    [SerializeField] private GameObject _commandMenu = null;
    [SerializeField] private GameObject _buttonObject = null;
    private float _maxTimeDelay = 0.1f;
    private float currentTimeDelay = 0f;
    private bool activeDelay = false;
    private InputAction _horizontalAxis = null;


    private bool _isPaused = false;


    public bool IsPaused => _isPaused;

    public GameObject CommandMenu => _commandMenu;


    [SerializeField] string _inputToCheck = "Pause";
    [SerializeField] string _axisVer = "Ver";


    private void OnEnable()
    {

        _inputActionWrapper.TryFindAction(_axisVer, out _horizontalAxis, true);

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

        if (!_capacityMenu.isActiveAndEnabled)
        {
            if (!_isPaused == true)
            {
                SetPauseActive(true);
                SetSelectedButton(_focusedButton);
                SetPauseUIActive(true);
            }


            else
            {
                if (!_commandMenu.activeSelf)
                {
                    SetPauseActive(false);
                    SetSelectedButton(null);
                    //SetCommandMenuActive(false);
                    SetPauseUIActive(false);

                }

            }



        }

        
    }


    public void SetPauseActive(bool active)

    {
        if (active)
        {
            _isPaused = true;
            
            if (LevelReferences.Instance.PlayerReferences.TryGetCubeController(out CubeController cube))
            {

                cube.EnableJump(false);

            }  
            Time.timeScale = 0;
            
        }

        else
        {
            _isPaused = false;
            
           
            Time.timeScale = 1;

            activeDelay = true;
            

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

    public void SetSelectedButton(Button buttonToSelect)
    {

        if (_isPaused)
        {
            _eventSystem.SetSelectedGameObject(buttonToSelect.gameObject);
        }

        else
        {
            _eventSystem.SetSelectedGameObject(null);
        }

    }

    public void SetPauseUIActive(bool active)
    {
        _pauseUI.SetActive(active);

    }

    public void SetCommandMenuActive(bool active)
    {

        if (active)
        {
            _commandMenu.SetActive(true);
            _buttonObject.SetActive(true);
        }

        else
        {
            _commandMenu.SetActive(false);
            _buttonObject.SetActive(false);
        }

    }

    public void SetTimeScale(bool active)
    {
        if (active)
        {

            Time.timeScale = 1;

        }

        else
        {
            Time.timeScale = 0;
        }

    }


    public void SetCommandMenu(bool active)
    {


        _commandMenu.SetActive(active);

    }
}
