using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{

    public float disableTime = 4f;
    
    // Update is called once per frame
    void Update()
    {
        
        
        if(Time.time > disableTime)
        {
            gameObject.SetActive(false);

        }
    }
}
