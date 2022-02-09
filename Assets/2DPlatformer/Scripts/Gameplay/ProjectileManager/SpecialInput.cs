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
    [SerializeField] string _inputSelect = "Select";
    [SerializeField] string _inputB = "B";

    private InputAction _inputThrowAction = null;
    private InputAction _inputHorizontalAxis = null;
    private InputAction _inputVerticalAxis = null;
    private InputAction _inputAddAction = null;
    private InputAction _inputActiveLauncherAction = null;
    private InputAction _inputLeftVertcialAxis = null;
    private InputAction _inputSkipDialogueAction = null;
    private InputAction _inputSelectAction = null;
    private InputAction _inputBAction = null;

    [SerializeField] ProjectileManager _projectileManager = null;
    [SerializeField] ThrowableLauncher _throwableLauncher = null;
    [SerializeField] ItemManager _itemManager = null;
    [SerializeField] CheckPebbleState _pebbleState = null;
    [SerializeField] Pause _pause = null;
    [SerializeField] CapacityMenu _capicity = null;
    [SerializeField] GameObject _pauseUI = null;
    [SerializeField] AudioSource _audioSource = null;
    [SerializeField] Animator _animator = null;
    
     

    private PlayerCheckClimbWall _playerCheckClimbWall = null;
    private CheckDestructible _checkDestructible = null;
    private NPCDetector _npcDetector = null;
    private TPPlayer _tpPlayer = null;
    


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
        _tpPlayer = LevelReferences.Instance.PlayerReferences.GetComponentInParent<TPPlayer>();


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


        if (_inputActionMap.TryFindAction(_inputSelect, out _inputSelectAction, true) == true)
        {

            _inputSelectAction.performed -= inputSelectActionPerformed;
            _inputSelectAction.performed += inputSelectActionPerformed;
        }

        if (_inputActionMap.TryFindAction(_inputB, out _inputBAction, true) == true)
        {
            _inputBAction.performed -= _inputBPerformed;
            _inputBAction.performed += _inputBPerformed;
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
        if (_itemManager.CheckProjectileCountIsSuperiorThan0())
        {
            _animator.SetTrigger("PrepareThrow");
            _throwableLauncher.gameObject.SetActive(true);
            _throwableLauncher.SetActive(true);
            
            
        }

        

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

            _audioSource.clip = LevelReferences.Instance.AudioManager.GetSound(9);
            _audioSource.Play();
            Destroy(_checkDestructible.CurrentDestructibleWall.gameObject);


        }

        else if (_npcDetector != null && _npcDetector.CurrentInteractableNPC != null)
        {


              
            _npcDetector.SetInDialogue(true);
            LevelReferences.Instance.UIManager.SetTextAndSprite(LevelReferences.Instance.UIManager.ListText[1], LevelReferences.Instance.UIManager.ListSprite[1]);

            
            

        }

        else if (_tpPlayer.IsInArea)
        {

            _tpPlayer.StartTimer(true);

        }

       
    }

    private void inputSelectActionPerformed(InputAction.CallbackContext obj)
    {
        if (!_pauseUI.gameObject.activeSelf)
        {
            if (!_pause.IsPaused)
            {
                _pause.SetPauseActive(true);
                _capicity.gameObject.SetActive(true);

                for (int i = 0; i < _capicity.ListButton.Count; i++)
                {
                    if (_capicity.ListButton[i].isActiveAndEnabled)
                    {
                        _pause.SetSelectedButton(_capicity.ListButton[i]);

                        break;
                    }
                }
                
               

            }

            else
            {
               
                _pause.SetPauseActive(false);
                _pause.SetSelectedButton(null);
                //_capicity.CapacityPicture.gameObject.SetActive(false);
                _capicity.gameObject.SetActive(false);
            }


        }
        


    }

    private void _inputBPerformed(InputAction.CallbackContext obj)
    {

        if (_pause.CommandMenu.gameObject.activeSelf)
        {
            _pause.CommandMenu.gameObject.SetActive(false);
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

        _inputSelectAction.performed -= inputSelectActionPerformed;
        _inputSelectAction.Disable();

        _inputBAction.performed -= _inputBPerformed;
        _inputBAction.performed += _inputBPerformed;
    }

    private void Update()
    {





    }
}
