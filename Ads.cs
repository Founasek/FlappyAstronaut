using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour {

    static int AdsCounter = 0;

    void Start()
    {
       if(AdsCounter == 4)
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
#if UNITY_ADS
        if (Advertisement.IsReady() && AdsCounter == 3)
        {
            Advertisement.Show();
            AdsCounter = 0;
        }
#endif
    }
}
