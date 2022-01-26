using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableNewTest : MonoBehaviour
{

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
}
