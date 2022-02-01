namespace GSGD2.Gameplay
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    /// <summary>
	/// PickupCommand used to modify player health. It can be workarounded to poison the player, but it shouldn't be used that way, since it will not call TakeDamage() and trigger the chain of events.
	/// </summary>
	[CreateAssetMenu(menuName = "GameSup/ActiveWallClimb", fileName = "ActiveWallClimb")]
    public class ActiveWallClimb : PickupCommand
    {
		// Start is called before the first frame update
		protected override bool ApplyPickup(ICommandSender from)
		{
		  PlayerCheckClimbWall checkClimbWall =	LevelReferences.Instance.PlayerReferences.GetComponentInParent<PlayerCheckClimbWall>();

            if (checkClimbWall != null)
            {
                if (!checkClimbWall.IsActive)
                {

                    checkClimbWall.SetActive(true);
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
