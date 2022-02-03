using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;
using UnityEngine.InputSystem;
using GSGD2;

public class MainMenuInput : MonoBehaviour
{
    [SerializeField] InputActionMapWrapper _inputActionMap = null;
    [SerializeField] string _inputA = "A";
    [SerializeField] string _vercticalAxisToCheck = "Ver";
    [SerializeField] string _horizontalAxisToCheck = "Hor";
    [SerializeField] string _inputB = "B";
    

    private InputAction _inputAAction = null;
    private InputAction _inputHorizontalAxis = null;
    private InputAction _inputVerticalAxis = null;
    private InputAction _inputBAction = null;

    [SerializeField] MainMenu _mainMenu = null;
   

    


    



    public float HorizontalAxis => _inputHorizontalAxis.ReadValue<float>();
    public float VerticalAxis => _inputVerticalAxis.ReadValue<float>();

    

    private void Start()
    {
       


    }

    private void OnEnable()
    {
        _inputActionMap.TryFindAction(_vercticalAxisToCheck, out _inputVerticalAxis, true);
        _inputActionMap.TryFindAction(_horizontalAxisToCheck, out _inputHorizontalAxis, true);
     

        if (_inputActionMap.TryFindAction(_inputA, out _inputAAction) == true)
        {
            _inputAAction.performed -= _inputAActionPerformed;
            _inputAAction.performed += _inputAActionPerformed;

        }

        _inputAAction.Enable();


        if (_inputActionMap.TryFindAction(_inputB, out _inputBAction, true) == true)
        {
            _inputBAction.performed -= _inputBActionPerformed;
            _inputBAction.performed += _inputBActionPerformed;

        }

        
    }

    private void _inputAActionPerformed(InputAction.CallbackContext obj)
    {


        _mainMenu.PressAButton();


    }

    private void _inputBActionPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("PRESS B");
        _mainMenu.PressBButton();
        

    }


   




   

    private void OnDisable()
    {
        _inputAAction.performed -= _inputAActionPerformed;
        _inputAAction.Disable();

        _inputAAction.performed -= _inputAActionPerformed;
        _inputAAction.Disable();

        
    }

    private void Update()
    {





    }
}
