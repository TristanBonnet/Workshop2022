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
    [SerializeField] string _leftVerticalAxisToCheck = "LeftVer";
    [SerializeField] string _inputSkipDialogue = "skip";

    private InputAction _inputThrowAction = null;
    private InputAction _inputHorizontalAxis = null;
    private InputAction _inputVerticalAxis = null;
    private InputAction _inputAddAction = null;
    private InputAction _inputActiveLauncherAction = null;
    private InputAction _inputLeftVertcialAxis = null;
    private InputAction _inputSkipDialogueAction = null;

    [SerializeField] ProjectileManager _projectileManager = null;
    [SerializeField] ThrowableLauncher _throwableLauncher = null;
    [SerializeField] ItemManager _itemManager = null;
    [SerializeField] CheckPebbleState _pebbleState = null;
    

    private PlayerCheckClimbWall _playerCheckClimbWall = null;
    private CheckDestructible _checkDestructible = null;
    private NPCDetector _npcDetector = null;
    


    public float HorizontalAxis => _inputHorizontalAxis.ReadValue<float>();
    public float VerticalAxis => _inputVerticalAxis.ReadValue<float>();

    public float LeftVerticalAxis => _inputLeftVertcialAxis.ReadValue<float>();

    private void Start()
    {
        _itemManager =  LevelReferences.Instance.ItemManager;
        _pebbleState = LevelReferences.Instance.PlayerReferences.GetComponentInParent<CheckPebbleState>();
        _playerCheckClimbWall = LevelReferences.Instance.PlayerReferences.GetComponentInParent<PlayerCheckClimbWall>();
        _checkDestructible = LevelReferences.Instance.PlayerReferences.GetComponentInParent<CheckDestructible>();
        _npcDetector = LevelReferences.Instance.PlayerReferences.GetComponentInParent<NPCDetector>();



    }

    private void OnEnable()
    {
         _inputActionMap.TryFindAction(_vercticalAxisToCheck, out _inputVerticalAxis, true);
         _inputActionMap.TryFindAction(_horizontalAxisToCheck, out _inputHorizontalAxis, true);
         _inputActionMap.TryFindAction(_leftVerticalAxisToCheck, out _inputLeftVertcialAxis, true);

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


        if (_inputActionMap.TryFindAction(_inputSkipDialogue, out _inputSkipDialogueAction, true) == true)
        {

            _inputSkipDialogueAction.performed -= inputSkipDialogue;
            _inputSkipDialogueAction.performed += inputSkipDialogue;

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
        
        
        _throwableLauncher.gameObject.SetActive(true);
        _throwableLauncher.SetActive(true);

    }


    private void inputSkipDialogue(InputAction.CallbackContext obj)
    {
        if (_npcDetector.CurrentInteractableNPC != null && _npcDetector.InDialogue)
        {

            _npcDetector.GetNextSentence();

        }


    }




    private void _inputActionReloadPerformed(InputAction.CallbackContext obj)
    {
        if (_pebbleState != null &&_pebbleState.OnPebbles)
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

        else if (_pebbleState != null && _pebbleState.OnPebbles)
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

        else if (_playerCheckClimbWall.CheckIfPlayerCanWallRun())
        {
            if (_playerCheckClimbWall.IsActive)
            {
                _playerCheckClimbWall.SetClimb(true);
            }

            


        }

        else if (_checkDestructible.CurrentDestructibleWall != null)
        {

            Destroy(_checkDestructible.CurrentDestructibleWall.gameObject);


        }

        else if (_npcDetector != null && _npcDetector.CurrentInteractableNPC != null)
        {


              
            _npcDetector.SetInDialogue(true);

            
            

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

        _inputSkipDialogueAction.performed -= inputSkipDialogue;
        _inputSkipDialogueAction.Disable();
    }

    private void Update()
    {





    }
}
