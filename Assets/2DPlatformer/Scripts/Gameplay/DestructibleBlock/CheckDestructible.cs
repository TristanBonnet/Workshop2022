using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDestructible : MonoBehaviour
{
    [SerializeField] Transform _startTransform = null;
    [SerializeField] float _distance = 1;
    [SerializeField] bool _isActive = false;
     private DestructibleBlock _currentDestructibleWall = null;


    public bool IsActive => _isActive;
    public DestructibleBlock CurrentDestructibleWall => _currentDestructibleWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {

            Debug.DrawLine(_startTransform.position, _startTransform.transform.forward * _distance, Color.black);
            if (Physics.Raycast(_startTransform.position, _startTransform.forward, out RaycastHit hit, _distance))
            {
                Debug.Log("HIT DESTRUCTIBLE");
                DestructibleBlock destructibleWall = hit.collider.GetComponentInParent<DestructibleBlock>();

                if (destructibleWall != null)
                {

                    _currentDestructibleWall = destructibleWall;


                }

                else
                {
                    if (_currentDestructibleWall != null)
                    {
                        _currentDestructibleWall = null;
                    }


                }

            }

            else
            {
                if (_currentDestructibleWall != null)
                {
                    _currentDestructibleWall = null;
                }
            }

        }
    }


    public void SetActive (bool isActive)
    {

        _isActive = isActive;


    }
}
