using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour {

    static int AdsCounter = 0;

    void Start()
    {
       if(AdsCounter == 10) // If condition is true -> call function adsShow to play ad
        {
            AdsCounter = 0;
            AdsShow();
        }
       else
        {
            AdsCounter++;
        } 
    }

    public void AdsShow()
    {

         if (Advertisement.IsReady() && AdsCounter == 10) // If Ad is loaded by Unity and adsCounter is >= 10 -> Play ad and reset counter
         {
             Advertisement.Show();
             AdsCounter = 0;
         }
         
    }
}
