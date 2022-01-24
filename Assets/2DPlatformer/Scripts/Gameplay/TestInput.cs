namespace GSGD2.Gameplay
{



    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Player;
    using UnityEngine.InputSystem;

    public class TestInput : MonoBehaviour
    {
        [SerializeField]
        private InputActionMapWrapper _inputActionMap = null;

        [SerializeField] Shop _shop = null;

        private InputAction _abilityImproverInteractionAction = null;





        private void OnEnable()
        {
            if (_inputActionMap.TryFindAction("AbilityImproverInteraction", out _abilityImproverInteractionAction) == true)
            {
                _abilityImproverInteractionAction.performed -= _abilityImproverInteractionAction_performed;
                _abilityImproverInteractionAction.performed += _abilityImproverInteractionAction_performed;
                
            }

            _abilityImproverInteractionAction.Enable();


        }

        private void _abilityImproverInteractionAction_performed(InputAction.CallbackContext obj)
        {
            
            if (_shop.GetShopOpen() == true)
            {
                _shop.SetShopOpen(false);
            }

            else
            {
                _shop.SetShopOpen(true);
            }
        }

        private void OnDisable()
        {
            _abilityImproverInteractionAction.performed -= _abilityImproverInteractionAction_performed;
            _abilityImproverInteractionAction.Disable();
        }

        
    }
}