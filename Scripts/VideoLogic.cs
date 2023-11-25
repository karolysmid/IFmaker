using System.Runtime.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

[ExecuteInEditMode]
public class VideoLogic : MonoBehaviour
{
 [Header("Game Object controls")]
 
    public GameObject buttonPrefab;
    
    public string buttonPrefabTag = "buttonPrefab";
    public GameObject container;
    [Tooltip("The name of the tag of the item")]
    public string containerTag = "ButtonContainer";
      [Tooltip("Force the creation of a button if there is only one child node")]
    public bool forceButton = false;
    public float distance = 5f;
      [Tooltip("Crop the video. It will start at frame")]
       [Header("Video Controls")]
    public long cropStart= 0;
   
    public float cropEnd=30;
    [ContextMenuItem("Reset Variable", "ResetVariable")]
    public float timer;
    public GameObject UITimerBar;
    private Vector3 timerBarSize;
    VideoPlayer vp; 

    List<Transform> buttontransforms;




    void ResetVariable()
    {
       timer=0;
    }









    void  OnDisable()
    {
        gameObject.GetComponent<VideoPlayer>().enabled = false;
        ClearChoices();
    }
    void OnEnable()
    {
        FindAssets();
        vp = GetComponent<VideoPlayer>();
        vp.frame=cropStart;
        gameObject.GetComponent<VideoPlayer>().enabled = true;
        //updating buttons
        ClearChoices();
        UITimerBar.transform.localScale = timerBarSize;
        if(GetComponent<VideoPlayer>().isActiveAndEnabled)
            {
                MakeButtonsForChildren();
            }

      

        
    }

    private VideoPlayer.EventHandler LoopPointReached()
    {
        throw new NotImplementedException();
    }

    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        timerBarSize = UITimerBar.transform.localScale;
    }

    

    void Update()
    {

        //Creates the new buttons while running if there are none 
        if (vp.isActiveAndEnabled && container.transform.childCount == 0 && transform.childCount > 0)
        {
            MakeButtonsForChildren();
        }

        //Move to next scene if the crop frame has been reached
        MoveToNextScene();

         // vp.loopPointReached += LoopPointReached(); if we would want to do something once the video has ended. Causes bugs


        //will be used to shrink the panel based on remaining time
       if(timer >0|| true)
       {
        
            if(vp.frame >= vp.frameCount-timer*vp.frameRate || true)
            {
                float scale = 1-(float)((double) vp.frame / (double) vp.frameCount);
                
                UITimerBar.transform.localScale = new Vector3(scale,UITimerBar.transform.localScale.y,UITimerBar.transform.localScale.z);
            }
       }

    }

    private void MoveToNextScene()
    {
        if (vp.frame >= (long)vp.frameCount - cropEnd && !forceButton && transform.childCount == 1)
        {
            vp.enabled = false;
            
            transform.GetChild(0).GetComponent<VideoLogic>().enabled = true;
        }
    }

    //Executes on change of values in the Editor mode
    void OnValidate()
    {
        FindAssets();
        ClearChoices();
        if(GetComponent<VideoPlayer>().isActiveAndEnabled)
            {
                MakeButtonsForChildren();
            }
       

    }

    //Makes sure the values are assigned
    private void FindAssets()
    {
         if(buttonPrefab == null || container == null)
        {
            buttonPrefab = GameObject.FindGameObjectWithTag(buttonPrefabTag);
            container = GameObject.FindGameObjectWithTag("ButtonContainer");
            try{
            GetComponent<VideoPlayer>().targetCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            }catch(Exception)
            {
                Debug.Log("Something went wrong with overriding camera input. The Videoplayers should all override the camera near plane");
            }
            UITimerBar = GameObject.FindGameObjectWithTag("UITIMERBAR");
            timerBarSize = UITimerBar.transform.localScale;

        }
    }
    public void MakeButtonsForChildren(Transform container)
    {
        Vector3 v = new Vector3(0,distance,0);
            foreach(Transform child in container)
            {
                child.position += v;
            }




    }




    public void MakeButtonsForChildren()
    {
       
       //This method creates buttons corresponding to the child objects' names.
        Transform parentTransform = transform;
        Vector3 placer = Vector3.zero;
        placer = container.transform.position;
        
        if(parentTransform.GetComponentInChildren<EnableOnFrame>() == null)
        {

            if(parentTransform.childCount >1 && container.transform.childCount < parentTransform.childCount)
            {
            // Iterate through all immediate children
                for (int i = 0; i < parentTransform.childCount; i++)
                {
                    Transform child = parentTransform.GetChild(i);
                   
                    placer = CreateButtons(placer, child);

                }
                // placeholder solution to facilitate having the option of forcing the creation of the button
            }
            else if(parentTransform.childCount == 1 && container.transform.childCount < parentTransform.childCount && forceButton)
            {
                Transform child = parentTransform.GetChild(0);
                placer = CreateButtons(placer, child);
            }
        }




        
    }

    private Vector3 CreateButtons(Vector3 placer, Transform child)
    {
        try
        {
            //Instantiates a new button based on the prefab into the container object
            GameObject newButton = Instantiate(buttonPrefab, container.transform);
            //The name of the button should be the same as the name of the child
            newButton.name = child.name;
            //The text on the button is its name
            newButton.transform.GetChild(0).GetComponent<Text>().text = child.name;
            //Places the child according to the distance provided
            newButton.transform.position = placer;
            placer.x += distance;
            //The child's videoplayer will be the enabled component
            newButton.GetComponent<SwitchScene>().VideoPlayertoEnable = child.GetComponent<VideoLogic>();
        }
        catch (Exception)
        {
            Debug.LogError("Something went wrong with instantiating the buttons. Are you sure they are assigned? ");
        }

        return placer;
    }

    private void ClearChoices()
    {
        
        foreach(Transform child in container.transform)
            {
                if(child.gameObject != null && child != null)
                {
                    //This delay call is necessary, it won't work otherwise. It still produces an error at this stage
                    
                    //UnityEditor.EditorApplication.delayCall+=()=>
                    //{
                    DestroyImmediate(child.gameObject);
                   // };
                }
                
                
            }
        
       
    }
}
