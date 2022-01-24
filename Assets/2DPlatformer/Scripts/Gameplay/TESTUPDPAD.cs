namespace GSGD2.Gameplay
{



    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;

    public class TESTUPDPAD : MonoBehaviour
    {
        [SerializeField]
        private InputActionMapWrapper _inputActionMap = null;
        [SerializeField] string _inputToCheck = "AbilityImproverInteraction";
        
        

        [SerializeField] int _indexInstanciate = 0;



        [SerializeField] Shop _shop = null;

        private InputAction _UPInteraction = null;
        private InputAction _RIGHTInteraction = null;
        private InputAction _DOWNInteraction = null;
        private InputAction _LEFTInteraction = null;




        private void OnEnable()
        {
            if (_inputActionMap.TryFindAction("UP", out _UPInteraction, true) == true)
            {
                _UPInteraction.performed -= _UPAbility;
                _UPInteraction.performed += _UPAbility;

            }

            if (_inputActionMap.TryFindAction("RIGHT", out _RIGHTInteraction, true) == true)
            {
                _RIGHTInteraction.performed -= _RIGHTAbility;
                _RIGHTInteraction.performed += _RIGHTAbility;

            }

            if (_inputActionMap.TryFindAction("DOWN", out _DOWNInteraction, true) == true)
            {
                _DOWNInteraction.performed -= _DOWNAbility;
                _DOWNInteraction.performed += _DOWNAbility;

            }

            if (_inputActionMap.TryFindAction("LEFT", out _DOWNInteraction, true) == true)
            {

                _LEFTInteraction.performed -= _LEFTAbility;
                _LEFTInteraction.performed += _LEFTAbility;

            }
        }

        private void _UPAbility(InputAction.CallbackContext obj)
        {
            _shop.InstantiateObject(0);
            
        }

        private void _RIGHTAbility(InputAction.CallbackContext obj)
        {
            _shop.InstantiateObject(1);

        }
        private void _DOWNAbility(InputAction.CallbackContext obj)
        {
            _shop.InstantiateObject(2);

        }

        private void _LEFTAbility(InputAction.CallbackContext obj)
        {
            _shop.InstantiateObject(3);

        }



        private void OnDisable()
        {
            _UPInteraction.performed -= _UPAbility;
            _DOWNInteraction.performed -= _DOWNAbility;
            _RIGHTInteraction.performed -= _RIGHTAbility;
            _LEFTInteraction.performed -= _LEFTAbility;

            _UPInteraction.Disable();
            _DOWNInteraction.Disable();
            _RIGHTInteraction.Disable();
            _LEFTInteraction.Disable();
        }


    }
}