using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject PublicData;
    public bool JC=true;
    public Text MainText;
    public int roomCount=0;
    public GameObject InMatch;
    public Text InRoomInt;
    public float StartCount=3;
    public Text StartCountText;
    public GameObject CHO;
    // Start is called before the first frame update
    void Awake() => Screen.SetResolution(960, 540, false);
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
        
    }

    // Update is called once per frame
     void Update()
    {
       
        
        if(InMatch.activeSelf==true){
            InRoomInt.text=PhotonNetwork.CurrentRoom.PlayerCount.ToString()+"/2";
        }
        if(CHO.activeSelf==true){
            StartCountText.text=Mathf.Ceil(StartCount).ToString();
        }
        MainText.text = PhotonNetwork.NetworkClientState.ToString();
        PhotonNetwork.LocalPlayer.NickName = "ME";
        if(PhotonNetwork.InRoom){
            if(PhotonNetwork.CurrentRoom.PlayerCount==2){
                if((int)StartCount==-1){
                    SceneManager.LoadScene("Game");
                }
                CHO.SetActive(true);
                StartCount-=Time.deltaTime*1;
                
                
            }
            else{
                CHO.SetActive(false);
                StartCount=3;
            }
        }
        
    }

    public void Connect()=> PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster(){
        print("서버접속에 완료했습니다.");
        PhotonNetwork.JoinLobby();
    
    }
    
    public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom(Judge(), new RoomOptions { MaxPlayers = 2 }, null);
    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();
 
    public override void OnJoinRandomFailed(short returnCode, string message) => print("방랜덤참가실패");
    public string Judge()
    {
        string Room1="안녕하세요";
        if(PhotonNetwork.CountOfRooms>0){
            Room1=Random.Range(1,roomCount).ToString();
            
        }
        else{
            Room1="1";
        }
        return Room1;
    }
    
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        roomCount=roomList.Count;
    }

    public override void OnJoinedRoom(){
        if(PhotonNetwork.CurrentRoom.PlayerCount==2){
            PublicData.GetComponent<DataScript>().Color="red";
        }
        else{
            PublicData.GetComponent<DataScript>().Color="blue";
        }
        InMatch.SetActive(true);
        
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        InMatch.SetActive(false);
        StartCount=3;
    }

    [ContextMenu("정보")]
    void Info()
    {
        if (PhotonNetwork.InRoom)
        {
            print("현재 방 이름 : " + PhotonNetwork.CurrentRoom.Name);
            print("현재 방 인원수 : " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("현재 방 최대인원수 : " + PhotonNetwork.CurrentRoom.MaxPlayers);

            string playerStr = "방에 있는 플레이어 목록 : ";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerStr += PhotonNetwork.PlayerList[i].NickName + ", ";
            print(playerStr);
        }
        else
        {
            print("접속한 인원 수 : " + PhotonNetwork.CountOfPlayers);
            print("방 개수 : " + PhotonNetwork.CountOfRooms);
            print("모든 방에 있는 인원 수 : " + PhotonNetwork.CountOfPlayersInRooms);
            print("로비에 있는지? : " + PhotonNetwork.InLobby);
            print("연결됐는지? : " + PhotonNetwork.IsConnected);
        }
    }

    
}

