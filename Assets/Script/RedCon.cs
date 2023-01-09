using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class RedCon : MonoBehaviour
{
    public string Mana;
    public GameObject NowClickOJ;
    public bool ClickMe=false;
    public int posi;
    public HelpScript script;
    // Start is called before the first frame update
    void Start()
    {
        script =GameObject.Find("Main Camera").GetComponent<HelpScript>();
         
    }
    public void GameST()
    {
        Mana=GameObject.Find("PublicData").GetComponent<DataScript>().Color;
        
    }


    // Update is called once per frame
    void Update()
    {
        NowClickOJ=GameObject.Find("Main Camera").GetComponent<HelpScript>().ClcikUnit;
       
    }
    private void OnMouseUpAsButton()
    {
            if(Mana=="red"){
            ///////////////
                if(NowClickOJ.name!="nomalfield"){
                    NowClickOJ.GetComponent<RedCon>().ClickMe=false;
                }
            
                ClickMe=true;
                GameObject.Find("Main Camera").GetComponent<HelpScript>().ClcikUnit=gameObject;
                /////////
                if(script.RedTurn){
                    OnGreenPosi();
                }
            }
    }
    void OnGreenPosi()
    {
        posi=this.GetComponent<UnitMoveScript>().onposi;
        
        for(int i=0; i<5; i++){
            script.GreenField[i].SetActive(false);
        }
        
        if(posi==0){
            if(script.FieldCk[2]==false){
                
                script.GreenField[2].SetActive(true);
            }
            else if(script.FieldCk[4]==false){
                
                script.GreenField[4].SetActive(true);
            }
        }
        else if(posi==1){
            if(script.FieldCk[3]==false){
                
                script.GreenField[3].SetActive(true);
            }
            else if(script.FieldCk[4]==false){
                
                script.GreenField[4].SetActive(true);
            }
        }
        else if(posi==2){
            if(script.FieldCk[0]==false){
                
                script.GreenField[0].SetActive(true);
            }
            else if(script.FieldCk[3]==false){
                
                script.GreenField[3].SetActive(true);
            }
            else if(script.FieldCk[4]==false){
                
                script.GreenField[4].SetActive(true);
            }
        }
        else if(posi==3){
            if(script.FieldCk[1]==false){
                
                script.GreenField[1].SetActive(true);
            }
            else if(script.FieldCk[2]==false){
                
                script.GreenField[2].SetActive(true);
            }
            else if(script.FieldCk[4]==false){
                
                script.GreenField[4].SetActive(true);
            }
        }
        else if(posi==4){
            if(script.FieldCk[0]==false){
                
                script.GreenField[0].SetActive(true);
            }
            else if(script.FieldCk[1]==false){
                
                script.GreenField[1].SetActive(true);
            }
            else if(script.FieldCk[2]==false){
                
                script.GreenField[2].SetActive(true);
            }
            else if(script.FieldCk[3]==false){
                
                script.GreenField[3].SetActive(true);
            }
        }
    }
    
}
