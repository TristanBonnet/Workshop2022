using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Gameplay;
using UnityEngine.Events;

public class TeleportParent : MonoBehaviour
{
    [SerializeField] TeleportZone _teleportZone;
    [SerializeField] GameObject _uiTPZone;
    [SerializeField] PhysicsTriggerEvent _triggerEvent = null;

   
    public void SetTeleportZone(bool active)
    {

        _teleportZone.gameObject.SetActive(active);
        _uiTPZone.SetActive(active);

           

    }

    
}
