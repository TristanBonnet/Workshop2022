using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;
using UnityEngine.InputSystem;

public class SpecialInput : MonoBehaviour
{

    [SerializeField] InputActionMapWrapper _inputActionMap = null;
    [SerializeField] string _inputToCheck = "Throw";
    
    private InputAction _inputAction = null;
    private InputAction _inputAxis = null;

    [SerializeField] ProjectileManager _projectileManager = null;


    public float HorizontalAxis => _inputAxis.ReadValue<float>();

    private void OnEnable()
    {
         _inputActionMap.TryFindAction("ThrowableAxis", out _inputAxis, true);

        if (_inputActionMap.TryFindAction(_inputToCheck, out _inputAction) == true)
        {
            _inputAction.performed -= _inputThrowActionPerformed;
            _inputAction.performed += _inputThrowActionPerformed;

        }

        _inputAction.Enable();


    }

    private void _inputThrowActionPerformed(InputAction.CallbackContext obj)
    {

        _projectileManager.Fire();


    }

    private void OnDisable()
    {
        _inputAction.performed -= _inputThrowActionPerformed;
        _inputAction.Disable();
    }
}
