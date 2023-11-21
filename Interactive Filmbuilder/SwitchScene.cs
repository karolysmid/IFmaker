using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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



   /*
    public VideoPlayer VideoPlayertoEnable;
    //Activated on button press. The buttons are assigned a corresponding videoplayer that would be activated.
    public void CompleteSwitch ()
    {
  
        VideoPlayer[] otherVideoPlayers = GameObject.FindGameObjectWithTag("root").GetComponentsInChildren<VideoPlayer>();
        foreach(VideoPlayer vp in otherVideoPlayers)
        {
                    vp.gameObject.GetComponent<VideoLogic>().enabled = false;
        }
        VideoPlayertoEnable.gameObject.GetComponent<VideoLogic>().enabled = true;
      

    }
*/
  
}
