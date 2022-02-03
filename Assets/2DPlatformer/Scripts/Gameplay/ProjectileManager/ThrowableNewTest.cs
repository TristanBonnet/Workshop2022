using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableNewTest : MonoBehaviour
{
    [SerializeField] private Noise _noise = null;
    [SerializeField] private LayerMask _layer;
    public Rigidbody _rigibody = null;
    private float _gravityY = -9.81f;
    private Vector3 _gravity;

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        _rigibody.AddForce(_gravity);

        Movement();
        Collider[] _collidersList = Physics.OverlapSphere(transform.position, 0.2f, _layer);

        if (_collidersList.Length > 0)
        {
            Destroy(gameObject);
        }


    }
    


    private void Movement()
    {
        Vector3 direction = _rigibody.velocity;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.layer);

        if (other.gameObject.layer == 4)
        {
            Instantiate(_noise, transform.position, new Quaternion(0, 0, 0, 0));
            Debug.Log("MAKE NOISE");
            Destroy(gameObject);
        }

        else
        {
            Debug.Log("BAD LAYER");
        }
    }

    public void SetNewGravity(float multiplier)
    {

        _gravity = new Vector3(0, _gravityY * multiplier, 0);



    }

}
