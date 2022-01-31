using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2;
using GSGD2.Player;

public class TriggerActiveAI : MonoBehaviour
{
    [SerializeField] List<AIMovement> _listAI = null;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController _player = other.GetComponentInParent<PlayerController>();

        if (_player != null)
        {

            for (int i = 0; i < _listAI.Count; i++)
            {
                _listAI[i].ActiveAI();
            }

        }
    }
}
