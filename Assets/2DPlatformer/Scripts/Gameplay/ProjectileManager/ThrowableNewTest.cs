using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableNewTest : MonoBehaviour
{
    [SerializeField] private Noise _noise = null;
    [SerializeField] private LayerMask _layer;
   public Rigidbody _rigibody = null;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        Movement();


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

}
