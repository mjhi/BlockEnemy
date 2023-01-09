using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class GrennScript : MonoBehaviour
{
    HelpScript script; 
    // Start is called before the first frame update
    void Start()
    {
        script=GameObject.Find("Main Camera").GetComponent<HelpScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown(){
        script.ClcikUnit.GetComponent<Transform>().position = this.transform.position;

        for(int i=0; i<5; i++){
            script.GreenField[i].SetActive(false);
        }

        if(script.RedTurn){
            script.RedTurn=false;
        }
        else{
            script.RedTurn=true;
        }
        
        
    }
    
        
    
}
