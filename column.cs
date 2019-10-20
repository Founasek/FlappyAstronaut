using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class column : MonoBehaviour {

	
    // If astronauts flew through gap between column, add score
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {
            GameControl.instance.BirdScored();
        }
    }
}
