using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;
using UnityEngine.InputSystem;

public class SpecialInput : MonoBehaviour
{

    [SerializeField] InputActionMapWrapper _inputActionMap = null;
    [SerializeField] string _inputToCheck = "Throw";
    [SerializeField] string _vercticalAxisToCheck = "Ver";
    [SerializeField] string _horizontalAxisToCheck = "Hor";

    private InputAction _inputThrowAction = null;
    private InputAction _inputHorizontalAxis = null;

    private InputAction _inputVerticalAxis = null;

    [SerializeField] ProjectileManager _projectileManager = null;
    [SerializeField] ThrowableLauncher _throwableLauncher = null;


    public float HorizontalAxis => _inputHorizontalAxis.ReadValue<float>();
    public float VerticalAxis => _inputVerticalAxis.ReadValue<float>();

    private void OnEnable()
    {
         _inputActionMap.TryFindAction(_vercticalAxisToCheck, out _inputVerticalAxis, true);
         _inputActionMap.TryFindAction(_horizontalAxisToCheck, out _inputHorizontalAxis, true);

        if (_inputActionMap.TryFindAction(_inputToCheck, out _inputThrowAction) == true)
        {
            _inputThrowAction.performed -= _inputThrowActionPerformed;
            _inputThrowAction.performed += _inputThrowActionPerformed;

        }

        _inputThrowAction.Enable();


       

    }

    private void _inputThrowActionPerformed(InputAction.CallbackContext obj)
    {

        _throwableLauncher.Fire();
        Debug.Log("FIRE");


    }

    private void OnDisable()
    {
        _inputThrowAction.performed -= _inputThrowActionPerformed;
        _inputThrowAction.Disable();
    }

    private void Update()
    {





    }
}
