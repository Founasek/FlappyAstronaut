using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour {

    [Header("Best score")]
    public Text BestScoreText;

	void Update ()
    {
        BestScoreText.text = "Best score: " + PlayerPrefs.GetInt("HighScore", 0).ToString(); // Showing bestscore in UI
    }
	

}
