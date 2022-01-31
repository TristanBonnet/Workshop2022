using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    private bool _isActive = true;
    private float _timeDestroy = 0.1f;
    private float _currenTimeDestroy = 0;
    private List<AIMovement> _aiSensed = new List<AIMovement>();

    private void OnTriggerEnter(Collider other)
    {
        if (_isActive)
        {
            AIMovement _ai = other.GetComponentInParent<AIMovement>();

            if (_ai != null)
            {
                _aiSensed.Add(_ai);
            }

        }
    }

    private void Update()
    {
        if (_currenTimeDestroy < _timeDestroy)
        {

            _currenTimeDestroy += Time.deltaTime;

        }

        else
        {
            if (_aiSensed.Count > 0)
            {
                _aiSensed[CheckDistance()].SetNoiseLocation(transform.position);
            }
            Destroy(gameObject);
        }

    }


    private int CheckDistance()
    {
        int currentIndex = 0;
        float currentDistance = 0;
        for (int i = 0; i < _aiSensed.Count; i++)
        {
            if (i == 0)
            {
                currentDistance = Vector3.Distance(transform.position, _aiSensed[i].transform.position);
                currentIndex = 0;
            }

            else
            {
                float newDistance = Vector3.Distance(transform.position, _aiSensed[i].transform.position);
                if (newDistance < currentDistance)
                {
                    currentDistance = newDistance;
                    currentIndex = i;
                }
            }

        }

        return currentIndex;

    }
}
