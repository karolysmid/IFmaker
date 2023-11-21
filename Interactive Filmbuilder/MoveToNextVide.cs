using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MoveToNextVide : MonoBehaviour
{

 public  VideoPlayer vpnext;
 VideoPlayer vpthis;
    // Start is called before the first frame update
    void Start()
    {
         vpthis = GetComponent<VideoPlayer>();
        vpnext = transform.GetChild(0).gameObject.GetComponent<VideoPlayer>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if(vpthis.frame>(long)vpthis.frameCount- 30)
        {
            



            SwitchScene();
        }
    }

    private void SwitchScene()
    {
    
    {
  
       VideoPlayer[] otherVideoPlayers = GameObject.FindGameObjectWithTag("root").GetComponentsInChildren<VideoPlayer>();
       foreach(VideoPlayer vp in otherVideoPlayers)
       {
       vp.enabled = false;
       
       //vp.gameObject.SetActive(false);
     




        UnityEngine.Debug.Log(vp.gameObject.name +"should be off");
       }
        vpnext.enabled = true;
         foreach(Transform child in GameObject.FindGameObjectWithTag("ButtonContainer").transform)
        {
                if(child.gameObject != null && child != null)
                {

                    UnityEditor.EditorApplication.delayCall+=()=>
                    {
                    DestroyImmediate(child.gameObject);
                    };
                }
                
                
            }
        vpnext.gameObject.GetComponent<VideoLogic>().MakeButtonsForChildren();
      //  VideoPlayertoEnable.gameObject.SetActive(true);



    }
    }
}
