using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Player;

public class TriggerAudio : MonoBehaviour
{
    [SerializeField] private int _index = 0;

    [SerializeField] AmbientAudio _ambientAudio = null;


    private void OnTriggerEnter(Collider other)
    {
         PlayerController playerController = other.GetComponentInParent<PlayerController>();

        if (playerController != null)
        {
            if (_ambientAudio.CurrentIndexSound != _index)
            {

                _ambientAudio.PlaySound(_index);

            }
            
        }
    }



    
}
