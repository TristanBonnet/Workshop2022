using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2;
using GSGD2.Gameplay;
using GSGD2.Player;

public class HealZone : MonoBehaviour
{
    [SerializeField] bool _healMaxLife = true;
    [SerializeField] int _lifeToAdd = 1;



    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();

        if (player != null)
        {
            if (LevelReferences.Instance.PlayerReferences.TryGetPlayerDamageable(out PlayerDamageable playerDamageable) == true)
            {
                if (_healMaxLife)
                {

                    int newMaxHealth = Mathf.RoundToInt(playerDamageable.MaxHealth);
                    playerDamageable.RestoreHealth(newMaxHealth);
                    LevelReferences.Instance.UIManager.PlayerHUD2.UpdateLife();
                    
                   
                }


                else
                {
                    playerDamageable.RestoreHealth(_lifeToAdd);
                    LevelReferences.Instance.UIManager.PlayerHUD2.UpdateLife();
                }
            }


        }



    }

}
