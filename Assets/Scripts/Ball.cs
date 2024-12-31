using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public static Ball instance;
    public float ballSpeed;// ball speed at any given time

    public AudioClip leftSound;//audioclip - cd. an attribute not 
    public AudioClip rightSound;

    AudioSource audioInQuestion; //AudioSource - cd player
    Rigidbody2D rb;
    Vector2 velocity;
    
    void Awake(){
        if(instance == null){//if theres no ball
            instance = this; //ufk it we ball
        }else if(instance != this){//if somebody big ballin
            Destroy(gameObject);//kms
        }
    }
    // Start is called before the first frame update
    void Start(){

        audioInQuestion = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        float startDirectionX = Random.value;
float startDirectionY = Random.value;

        // Map 0 to -1 and 1 to 1
        int dirX = (startDirectionX < 0.5f) ? -1 : 1; //Ternary Operator (fancy if-statement) //? (is the condition met? k slay do -1)
        int dirY = (startDirectionY < 0.5f) ? -1 : 1;

        Vector2 ballDirection = new Vector2(dirX, dirY);
        rb.velocity = ballDirection * ballSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = velocity;// changing the velocity to the re
        velocity = rb.velocity;

        //this block of code is for boundaries
    }

    void OnCollisionEnter2D(Collision2D collision){
        
        Vector2 normal = collision.contacts[0].normal;// Normal is the outward direction of the object we hit
        
        Vector2 direction = Vector2.Reflect(velocity.normalized, normal.normalized);

        rb.velocity = direction * ballSpeed;
        //Play sound
        if(collision.gameObject.CompareTag("Player")){//collision.gameObject.CompareTag - look at the thing i hit, look at its game object then look at the tag it has
            if(transform.position.x < 0){//transform.position.X - where we are on the x axis on the scr- like literally the balls x coordinate (we are on the left side)
            audioInQuestion.PlayOneShot(leftSound);
        }else if(transform.position.x > 0){
            audioInQuestion.PlayOneShot(rightSound);
        }
        }
    }
}
