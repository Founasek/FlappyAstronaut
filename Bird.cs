using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    [Header("General")]
    public float FlappyForce = 200f;
    public bool isDead = false;

    [Header("Audio")]  
    public AudioClip hit;

    private Rigidbody2D myRigidBody;
    private AudioSource PlayerAudio;

    

    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        PlayerAudio = GetComponent<AudioSource>();
       
    } 
    void Update ()
    {
        if (isDead == false)
        {   
            // Main controls of the Astronaut while he is alive
            if (Input.GetMouseButtonDown(0) && GameControl.instance.reverseGravity == true)
            {     
                myRigidBody.velocity = Vector2.zero;
                myRigidBody.AddForce(new Vector2(0, (-FlappyForce)));
                GameControl.instance.StarGame = true;
            }
            if (Input.GetMouseButtonDown(0) && GameControl.instance.reverseGravity == false)
            {
                myRigidBody.velocity = Vector2.zero;
                myRigidBody.AddForce(new Vector2(0, (FlappyForce)));
                GameControl.instance.StarGame = true;
            }
        }
    }
     void OnCollisionEnter2D() // If collision is detected -> astronaut will die - END GAME - function GameControl.instance.BirdDied();
    {
        myRigidBody.velocity = Vector2.zero;
        isDead = true;
        PlayerAudio.PlayOneShot(hit);
        
        GameControl.instance.BirdDied();
    }   

   
}

