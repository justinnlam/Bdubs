using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Rigidbody rb;
    //float mspeed = 6f;
    GameObject Player;
    GameObject Player2;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");  
        Player.transform.position = new Vector3(0,1,0);
        Player2 = GameObject.Find("Player2");  
        Player2.transform.position = new Vector3(7,1,7);
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //rb.velocity = new Vector3(horizontalInput*mspeed, rb.velocity.y, verticalInput * mspeed);

        if (Input.GetKeyDown("space"))
        {
            floorfall();
        }
        if (Input.GetKeyDown("w"))
        {
            Player.transform.position += Vector3.forward;
        }
        else if (Input.GetKeyDown("a"))
        {
            Player.transform.position += Vector3.left;
        }
        else if (Input.GetKeyDown("d"))
        {
            Player.transform.position += Vector3.right;
        }
        else if (Input.GetKeyDown("s"))
        {
            Player.transform.position += Vector3.back;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Player2.transform.position += Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Player2.transform.position += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Player2.transform.position += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Player2.transform.position += Vector3.back;
        }        
    }       
 
    void floorfall()
    {
    int x = Random.Range(1, 8);
    int y = Random.Range(1, 8);
    GameObject cube = GameObject.Find("Cube"+x+y);  
    Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>(); // Add the rigidbody.
    }

}
