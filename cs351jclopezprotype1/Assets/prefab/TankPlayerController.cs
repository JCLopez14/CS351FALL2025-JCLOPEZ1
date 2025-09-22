using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerController : MonoBehaviour
{
    //a float to hold the speed of our tank player
   // try setting this to 8 in the inspector 
    public float speed;

    //float for our turn speed
    //try setting this to 100 in the inspector
    public float turnSpeed;

    public float horizontalInput;
    public float verticalInput;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move forward
        //transform.Translate(1, 0, 0);
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * Time.deltaTime * speed * verticalInput);

        transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);

    }

    
}
