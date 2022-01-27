using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;
using UnityEngine.InputSystem;
using GSGD2;

public class SpecialInput : MonoBehaviour
{

    [SerializeField] InputActionMapWrapper _inputActionMap = null;
    [SerializeField] string _inputToCheck = "Throw";
    [SerializeField] string _vercticalAxisToCheck = "Ver";
    [SerializeField] string _horizontalAxisToCheck = "Hor";
    [SerializeField] string _inputAddPebble = "Add";
    [SerializeField] string _inputActiveLauncher = "Launcher";

    private InputAction _inputThrowAction = null;
    private InputAction _inputHorizontalAxis = null;
    private InputAction _inputVerticalAxis = null;
    private InputAction _inputAddAction = null;
    private InputAction _inputActiveLauncherAction = null;

    [SerializeField] ProjectileManager _projectileManager = null;
    [SerializeField] ThrowableLauncher _throwableLauncher = null;
    [SerializeField] ItemManager _itemManager = null;
    [SerializeField] CheckPebbleState _pebbleState = null;
   
 

    public float HorizontalAxis => _inputHorizontalAxis.ReadValue<float>();
    public float VerticalAxis => _inputVerticalAxis.ReadValue<float>();

    private void Start()
    {
        _itemManager =  LevelReferences.Instance.ItemManager;
        _pebbleState = LevelReferences.Instance.PlayerReferences.GetComponentInParent<CheckPebbleState>();

    }

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


        if (_inputActionMap.TryFindAction(_inputAddPebble, out _inputAddAction , true) == true)
        {
            _inputAddAction.performed -= _inputActionReloadPerformed;
            _inputAddAction.performed += _inputActionReloadPerformed;


        }

        if (_inputActionMap.TryFindAction(_inputActiveLauncher, out _inputActiveLauncherAction, true) == true)
        {
            _inputActiveLauncherAction.performed -= _inputActiveProjectileLauncher;
            _inputActiveLauncherAction.performed += _inputActiveProjectileLauncher;


        }

    }

    private void _inputThrowActionPerformed(InputAction.CallbackContext obj)
    {

        if (_throwableLauncher.isActiveAndEnabled)
        {
            _itemManager.Fire();

        }

        _throwableLauncher.SetActive(false);
        _throwableLauncher.gameObject.SetActive(false);



    }

    private void _inputActiveProjectileLauncher(InputAction.CallbackContext obj)
    {
        Debug.Log("ACTIVE LAUNCHER");

        if (_itemManager.CheckProjectileCountIsSuperiorThan0())
        {
            _throwableLauncher.gameObject.SetActive(true);
            _throwableLauncher.SetActive(true);
        }

        

    }




    private void _inputActionReloadPerformed(InputAction.CallbackContext obj)
    {
        if (_throwableLauncher.isActiveAndEnabled)
        {
            _throwableLauncher.SetActive(false);
            _throwableLauncher.gameObject.SetActive(false);
        }

        else
        {
            if (_pebbleState != null && _pebbleState.OnPebbles)
            {
                if (_pebbleState.PebbleStock != null)
                {
                    if (_pebbleState.PebbleStock.InfinityStaack)
                    {
                        _itemManager.AddProjectile(1);
                    }

                    else
                    {
                        if (_pebbleState.PebbleStock.CurrentStack > 0)
                        {
                            _itemManager.AddProjectile(1);
                            _pebbleState.PebbleStock.RemoveStack(1);
                        }


                    }
                }


            }




        }


    }

    private void OnDisable()
    {
        _inputThrowAction.performed -= _inputThrowActionPerformed;
        _inputThrowAction.Disable();

        _inputAddAction.performed -= _inputActionReloadPerformed;
        _inputAddAction.Disable();

        _inputActiveLauncherAction.performed -= _inputActiveProjectileLauncher;
        _inputActiveLauncherAction.Disable();
    }

    private void Update()
    {





    }
}
