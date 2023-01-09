using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class HelpScript : MonoBehaviour
{
    
    public string PublicData;
    public GameObject ClcikUnit;
    public bool[] FieldCk;// 1,2,3,4,5 순서대로 왼쪽위 오른쪽위 왼쪽아래 오른쪽아래 미드
    public GameObject[] Field;
    public GameObject[] GreenField;
    public bool RedTurn;
    public PhotonView PV;
    public Vector3 oneposi;
    public Vector3 twoposi;
    // Start is called before the first frame update
    void Start()
    {
        RedTurn=false;
        PublicData=GameObject.Find("PublicData").GetComponent<DataScript>().Color;
        
        if(PublicData=="blue"){
            
            GameObject.Find("blue1").GetComponent<PhotonTransformView>().m_UseLocal=true;
            GameObject.Find("blue2").GetComponent<PhotonTransformView>().m_UseLocal=true;
            GameObject.Find("blue1").GetComponent<PhotonView>().IsMine=true;
            GameObject.Find("blue2").GetComponent<PhotonView>().IsMine=true;
            GameObject.Find("red1").GetComponent<PhotonView>().IsMine=false;
            GameObject.Find("red2").GetComponent<PhotonView>().IsMine=false;
            GameObject.Find("blue1").GetComponent<BlueCon>().GameST();
            GameObject.Find("blue2").GetComponent<BlueCon>().GameST();
            oneposi=GameObject.Find("red1").GetComponent<Transform>().position;
            twoposi=GameObject.Find("red2").GetComponent<Transform>().position;
        }
        if(PublicData=="red"){
            
            GameObject.Find("red1").GetComponent<PhotonTransformView>().m_UseLocal=true;
            GameObject.Find("red2").GetComponent<PhotonTransformView>().m_UseLocal=true;
          
            GameObject.Find("red1").GetComponent<PhotonView>().IsMine=true;
            GameObject.Find("red2").GetComponent<PhotonView>().IsMine=true;
            GameObject.Find("red1").GetComponent<RedCon>().GameST();
            GameObject.Find("red2").GetComponent<RedCon>().GameST();
            oneposi=GameObject.Find("blue1").GetComponent<Transform>().position;
            twoposi=GameObject.Find("blue2").GetComponent<Transform>().position;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if(PublicData=="blue"){
            if(oneposi!=GameObject.Find("red1").GetComponent<Transform>().position){
                oneposi=GameObject.Find("red1").GetComponent<Transform>().position;
                RedTurn=false;
                gameObject.GetComponent<InGameScript>().WinCk(false);
            }
            else if(twoposi!=GameObject.Find("red2").GetComponent<Transform>().position){
                twoposi=GameObject.Find("red2").GetComponent<Transform>().position;
                RedTurn=false;
                gameObject.GetComponent<InGameScript>().WinCk(false);
            }
        }
        else if(PublicData=="red"){
            if(oneposi!=GameObject.Find("blue1").GetComponent<Transform>().position){
                oneposi=GameObject.Find("blue1").GetComponent<Transform>().position;
                RedTurn=true;
                gameObject.GetComponent<InGameScript>().WinCk(true);
            }
            else if(twoposi!=GameObject.Find("blue2").GetComponent<Transform>().position){
                twoposi=GameObject.Find("blue2").GetComponent<Transform>().position;
                RedTurn=true;
                gameObject.GetComponent<InGameScript>().WinCk(true);
            }            
        }
    }
   





}
