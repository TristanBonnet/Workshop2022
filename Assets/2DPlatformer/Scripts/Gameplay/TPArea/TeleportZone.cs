using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Utilities;
using GSGD2.Player;
using UnityEngine.InputSystem;
public class TeleportZone : MonoBehaviour
{
   [SerializeField] LoadSceneComponent _loadSceneComponent = null;

    [SerializeField] InputActionMapWrapper _inputActionWrapper = null;


    [SerializeField] string _inputToCheck = "Teleport";
    [SerializeField] string _sceneName = "";

    private InputAction _TeleportInteraction = null;

    


    private void OnEnable()
    {
        if (_inputActionWrapper.TryFindAction("Teleport", out _TeleportInteraction, true) == true)
        {
            _TeleportInteraction.performed -= TeleportAbility;
            _TeleportInteraction.performed += TeleportAbility;

        }
    }

    private void TeleportAbility(InputAction.CallbackContext obj)
    {
        _loadSceneComponent.LoadScene(_sceneName);

    }

    private void OnDisable()
    {
        _TeleportInteraction.performed -= TeleportAbility;
        _TeleportInteraction.Disable();




    }

}
