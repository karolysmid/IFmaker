using System.Security.Cryptography;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization;

//[ExecuteInEditMode]
public class ChoicesDisplay : ScriptableObject
{
    public string title;
    public GameObject[] choices;
    public GameObject prefabPanel;
    public GameObject buttonContainer;
    public float spacing;
    Vector3 currentPosition = Vector3.zero;

}
  //  private void OnValidate()
  //  {
   //     Debug.Log(choices.Length);


     //   if (choices.Length>0)
         //   {
             //   for(int i=0; i<choices.Length; i++)
             //       {
                        

                 //   GameObject choiceButton = Instantiate(prefabPanel, buttonContainer.transform);
                        

                  //  Text buttonText = choiceButton.GetComponentInChildren<Text>();
                  //  buttonText.text =choices[i].name; 
                //    }

        //    }
      // }
    
    
/*
    void OnEnable()
    {
        currentPosition = buttonContainer.transform.position;
        Debug.Log("enabled in edit mode");


        for(int i=0; i<choices.Length; i++)
        {
            choices[i].GetComponent("");

        GameObject choiceButton = Instantiate(prefabPanel, buttonContainer.transform);
            

        Text buttonText = choiceButton.GetComponentInChildren<Text>();


        }
      

    
  //  buttonText.text=playerOption.text;

   // choiceButton.transform.localPosition = currentPosition;

    bool IsHorizontal = false;

      if(IsHorizontal)
        {
          currentPosition.x += spacing;
        }else{
        currentPosition.y -= spacing;
        
        }
      

    }
    // Start is called before the first frame update
   

    // Update is called once per frame
   
}
*/