namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.UI;

    [CreateAssetMenu(menuName = "GameSup/AddMaximumLifeSlot", fileName = "AddMaximumLifeSlot")]
    public class AddMaximumLifeSlot : PickupCommand
    {

        [SerializeField] private int _slotNumberToAdd = 1;


        protected override bool ApplyPickup(ICommandSender from)
        {
            PlayerDamageable playerDamageable = LevelReferences.Instance.PlayerReferences.GetComponentInParent<PlayerDamageable>();

            if (playerDamageable != null)
            {
                playerDamageable.IncrementMaxHealth(_slotNumberToAdd);

                    
                    LevelReferences.Instance.UIManager.PlayerHUD2.UpdateLife();


                
                
                return true;
            }

            else
            {
                return false;
            }

        }



    }

}
