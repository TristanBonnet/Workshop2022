namespace GSGD2.Gameplay
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;



    [CreateAssetMenu(menuName = "GameSup/ActiveDestructibleBlocks", fileName = "ActiveDestructibleBlocks")]
    public class ActiveDestructibleBlocks : PickupCommand
    {

        protected override bool ApplyPickup(ICommandSender from)
        {
            CheckDestructible checkDestructible = LevelReferences.Instance.PlayerReferences.GetComponentInParent<CheckDestructible>();

            if (checkDestructible != null)
            {
                if (!checkDestructible.IsActive)
                {
                    checkDestructible.SetActive(true);

                    if (!LevelReferences.Instance.CapacityMenu.SecondAbilityButton.isActiveAndEnabled)
                    {
                        LevelReferences.Instance.CapacityMenu.SetElementsVisibility(1, true);
                    }
                    return true;

                }

                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
            
        }




    }



}
