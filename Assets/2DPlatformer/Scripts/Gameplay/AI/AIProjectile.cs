using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2;
using GSGD2.Player;
using GSGD2.Gameplay;

public class AIProjectile : MonoBehaviour
{
    [SerializeField] float _projectileSpeed = 2f;
    [SerializeField] LayerMask _layer;
    private float _timeBeforeDestruction = 0;
   


    private void Update()
    {

        transform.position += transform.forward * _projectileSpeed * Time.deltaTime;


        if (_timeBeforeDestruction < 3)
        {
            _timeBeforeDestruction += Time.deltaTime;


        }

        else
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        PlayerController _player = other.GetComponentInParent<PlayerController>();


        if (_player != null)
        {

            Destroy(gameObject);

        }

        else if (other.gameObject.layer == _layer)
        {
            Destroy(gameObject);
        }
       


    }

}
