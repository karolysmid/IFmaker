using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Video;


public class SwitchScene : MonoBehaviour
{



    public VideoLogic VideoPlayertoEnable;
    //Activated on button press. The buttons are assigned a corresponding videoplayer that would be activated.
    public void CompleteSwitch ()
    {
  
        VideoLogic[] otherVideoPlayers = GameObject.FindGameObjectWithTag("root").GetComponentsInChildren<VideoLogic>();
        foreach(VideoLogic vp in otherVideoPlayers)
        {
                    vp.enabled = false;
        }
        VideoPlayertoEnable.enabled = true;
      

    }
     public static void CompleteSwitch (VideoLogic Ref_VideoPlayertoEnable)
    {
  
        VideoLogic[] otherVideoPlayers = GameObject.FindGameObjectWithTag("root").GetComponentsInChildren<VideoLogic>();
        foreach(VideoLogic vp in otherVideoPlayers)
        {
                    vp.enabled = false;
        }
        Ref_VideoPlayertoEnable.enabled = true;
      

    }


}
