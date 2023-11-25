using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MoveToNextVide : MonoBehaviour
{

[Tooltip("The reference to the next video to be loaded. Could be any of the previous ")]
 public  VideoLogic vpnext;
 VideoLogic vpthis;
 [Tooltip("Seconds to cut off before the video ends")]
 public float cropEnd;
 private VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
         vpthis = GetComponent<VideoLogic>();
       
    
    }

    // Update is called once per frame
    void Update()
    {
        if(vp.frame>=vp.frameCount-cropEnd*vp.frameRate)
        {
            
           SwitchScene.CompleteSwitch(vpnext);
        }
    }
}
