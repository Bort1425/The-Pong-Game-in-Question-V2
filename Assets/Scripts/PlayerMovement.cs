using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    Rigidbody2D rb; //Makes space in mem for object
    public float speed;
    public string rotateInputAxis;// this IS in fact the "horizontal" 
    public string verticalInputAxis;
    Vector2 move;
    public float screenBoundary = 4.2f;//sets height
    public float rotationSpeed;
    float rotationInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//finds rigidbody attached to the object before le game starts
        //rb.velocity = new Vector2(0f,1f);
    }//according to all known laws of aviation...

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(0f, Input.GetAxis(verticalInputAxis) * speed);
        rotationInput = Input.GetAxis(rotateInputAxis);

    //Rotate around the Vector 3 * the speed in which i am rotating * my current framerate * the rotationInput that i give it
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * -rotationInput); 
        
        //this block of code is for boundaries
        if(transform.position.y > screenBoundary){ //to keep the position of the player inside the box
            transform.position = new Vector2(transform.position.x,screenBoundary);
        }else if(transform.position.y <  -screenBoundary){
            transform.position = new Vector2(transform.position.x, -screenBoundary);
        }
    }

    //Rather than running once per frame it runs at a real-time delay
    //Slow and fast computers will run fixed update the same number of time
    void FixedUpdate()
    {
        rb.velocity = move;
    }
}
