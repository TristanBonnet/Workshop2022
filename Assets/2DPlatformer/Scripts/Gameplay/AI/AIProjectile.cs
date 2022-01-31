using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2;
using GSGD2.Player;

public class AIProjectile : MonoBehaviour
{
    [SerializeField] float _projectileSpeed = 2f;



    private void Update()
    {

        transform.position += transform.forward * _projectileSpeed * Time.deltaTime;

    }


    private void OnTriggerEnter(Collider other)
    {
        PlayerController _player = other.GetComponentInParent<PlayerController>();

        if (other != null)
        {

        }



    }

}
