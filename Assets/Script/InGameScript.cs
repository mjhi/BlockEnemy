using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InGameScript : MonoBehaviour
{
    public PhotonView PV;
    public string Color;
    public bool RedTurn;
    public int oneposiInt;
    public int twoposiInt;
    public bool[] fieldCK;
    public string GameResult;
    public Text result;
    public int resultInt=0;
    public GameObject EndGame;
    public int RestartInt=0;
    public GameObject EnemyLeave;
    public Text Wait;
    // Start is called before the first frame update
    void Start()
    {
        RedTurn=GameObject.Find("Main Camera").GetComponent<HelpScript>().RedTurn;
        Color=GameObject.Find("PublicData").GetComponent<DataScript>().Color;
    }

    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount==1){
            EndGame.SetActive(false);
            EnemyLeave.SetActive(true);
            
        }
        else if(RestartInt>=2){
            EndGame.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }

        
        if(resultInt==2){
            LooseGame();
        }
        if(GameResult=="loose"&&PhotonNetwork.CurrentRoom.PlayerCount==2){
            result.text="졌습니다";
            EndGame.SetActive(true);
        }
        else if(GameResult=="win"&&PhotonNetwork.CurrentRoom.PlayerCount==2)
        {
            result.text="이겼습니다!";
            EndGame.SetActive(true);
        }
        fieldCK=GameObject.Find("Main Camera").GetComponent<HelpScript>().FieldCk;
    }
    public void WinCk(bool redTrue)
    {
        resultInt=0;

        
        if(redTrue){
            oneposiInt=GameObject.Find("red1").GetComponent<UnitMoveScript>().onposi;
            twoposiInt=GameObject.Find("red2").GetComponent<UnitMoveScript>().onposi;
            if(Color=="red"){
                if(oneposiInt==4 || twoposiInt==4){return;}
                if(fieldCK[4]==true){
                                     BIGYO(oneposiInt);
                    BIGYO(twoposiInt);
                    if(resultInt==2){
                        LooseGame();
                    }
                }
            }

        }
        else{
            oneposiInt=GameObject.Find("blue1").GetComponent<UnitMoveScript>().onposi;
            twoposiInt=GameObject.Find("blue2").GetComponent<UnitMoveScript>().onposi;
            if(Color=="blue"){
                if(oneposiInt==4 || twoposiInt==4){return;}
                if(fieldCK[4]==true){
                    BIGYO(oneposiInt);
                    BIGYO(twoposiInt);
                    
                }
            }
        }
        
        
        
        

    }
    public void BIGYO(int posi)
    {   
        
        if(posi==0){
            if(fieldCK[2]==true){
                resultInt+=1;
            }
        
        }
        else if(posi==1){
            if(fieldCK[3]==true){
                resultInt+=1;
            }
        }
        else if(posi==2){
            if(fieldCK[0]==true && fieldCK[3]==true){
                resultInt+=1; 
            }
        }
        else if(posi==3){
            if(fieldCK[1]==true && fieldCK[2]==true){
                resultInt+=1; 
            }
        }
    }
    public void LooseGame()
    {
        GameResult="loose";
        PV.RPC("GameRT",RpcTarget.Others,true);
    }
    public void Restart()
    {     
        PV.RPC("RestartJoin",RpcTarget.All,true);
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("MainMeNu");
    }
    public void OK()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("MainMeNu");
    }

    [PunRPC]
    void GameRT(bool wewe){
        GameResult="win";
    }
    [PunRPC]
    void RestartJoin(bool weweqweqr){
        RestartInt+=1;
    }

}
