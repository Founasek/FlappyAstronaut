using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScollingObject : MonoBehaviour {


    private Rigidbody2D myRigidBody2D;
    
    
	void Start ()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myRigidBody2D.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
	}
	
	
	void Update ()
    {
        if (GameControl.instance.gameOver == true)
        {
            myRigidBody2D.velocity = Vector2.zero;
        }
	}
}
