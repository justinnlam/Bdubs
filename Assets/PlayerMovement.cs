using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float mspeed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput*mspeed, rb.velocity.y, verticalInput * mspeed);


        if (Input.GetKey("space"))
        {
            floorfall();
        }
        
    }       
 
    void floorfall()
    {

    }

}
