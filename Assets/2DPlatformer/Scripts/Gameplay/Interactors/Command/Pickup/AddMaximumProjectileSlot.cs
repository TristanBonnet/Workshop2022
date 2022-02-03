
namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.UI;

    [CreateAssetMenu(menuName = "GameSup/AddMaximumProjectileSlot", fileName = "AddMaximumProjectileSlot")]

    public class AddMaximumProjectileSlot : PickupCommand
    { 
        [SerializeField] private int _slotNumberToAdd = 1;


     protected override bool ApplyPickup(ICommandSender from)
    {
        PlayerDamageable playerDamageable = LevelReferences.Instance.PlayerReferences.GetComponentInParent<PlayerDamageable>();

        if (playerDamageable != null)
        {
             LevelReferences.Instance.ItemManager.AddMaxProjectileCount(_slotNumberToAdd);

            return true;
        }

        else
        {
            return false;
        }

    }



    }

}
