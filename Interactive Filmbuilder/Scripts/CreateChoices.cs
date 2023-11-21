using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[ExecuteInEditMode]
public class CreateChoices : MonoBehaviour
{

    void OnValidate()
    {

      VideoPlayer[] videoplayers = GetComponentsInChildren<VideoPlayer>(); 
      GetComponentInChildren<VideoPlayer>();
      Debug.Log(videoplayers.Length);
      
    }
   
}
