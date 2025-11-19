using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomView : MonoBehaviour
{
    [SerializeField] Text roomtext;

    [SerializeField] string titletext;

    public void OnConnectRoom()
    {
        PhotonNetwork.JoinRoom(titletext);
    }

    public void UpdateRoomInformation(RoomInfo roomInfo)
    {
        roomtext.text = roomInfo.Name + " ( " + roomInfo.PlayerCount + " / " + roomInfo.MaxPlayers + " ) ";
       
    }
}
