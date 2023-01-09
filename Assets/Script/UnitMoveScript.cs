using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveScript : MonoBehaviour
{
    public bool[] FieldCking;// 1,2,3,4,5 순서대로 왼쪽위 오른쪽위 왼쪽아래 오른쪽아래 미드
    public GameObject[] Fielding;
    public int onposi;
    public bool Color;
    
    // Start is called before the first frame update
    void Start()
    {
        FieldCking=GameObject.Find("Main Camera").GetComponent<HelpScript>().FieldCk;
        Fielding=GameObject.Find("Main Camera").GetComponent<HelpScript>().Field;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        for(int i=0; i<5; i++){
            if(other.name==Fielding[i].name){
                onposi=i;
                FieldCking[i]=true;
            }
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        for(int i=0; i<5; i++){
            if(other.name==Fielding[i].name){
                
                FieldCking[i]=false;
            }

        }
        
    }
}
