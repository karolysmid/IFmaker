using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Video;

public class EnableOnFrame : MonoBehaviour
{

    [Tooltip("The selected prefabs will be enabled x seconds before the end of the video")]
    public float cropSeconds;
    [Tooltip("Set this to true if you would like to enable something after x seconds in the video")]
    public bool FromStart=false;
    public GameObject[] ToEnable;


    VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        vp=GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(FromStart)
        {
            if(vp.frame >cropSeconds*vp.frameRate)
            {
                EnableSelected();
            }
        }else
        {
            if(vp.frame >vp.frameCount-cropSeconds*vp.frameRate)
            {
                EnableSelected();
            }
        }
    }

    private void EnableSelected()
    {
        foreach(GameObject go in ToEnable)
        {
            go.SetActive(true);
        }
    }
    private void DisableSelected()
    {
        foreach(GameObject go in ToEnable)
        {
            go.SetActive(false);
        }
    }
}
