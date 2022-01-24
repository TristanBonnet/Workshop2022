using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD2.Gameplay;
using GSGD2.Player;

public class ProjectileTurret : MonoBehaviour
{
    
    [SerializeField] float _projectileSpeed = 1f;
    private float _delayDestoy = 2f;
    private float _currentTimeDelayDestroy = 0;
    [SerializeField] DamageDealer _damageDealer = null;


   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _projectileSpeed * Time.deltaTime;

        if (_currentTimeDelayDestroy < _delayDestoy)
        {
            _currentTimeDelayDestroy += Time.deltaTime;
        }

        else
        {
            Destroy(this.gameObject);
        }


        
    }


    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();


        if (player != null)
        {

           

        }

        
    }


    private void OnTriggerExit(Collider other)
    {
        CubeController player = other.GetComponentInParent<CubeController>();


        if (player != null)
        {

            

        }


    }
}
