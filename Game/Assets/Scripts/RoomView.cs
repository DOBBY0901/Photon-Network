using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomView : MonoBehaviourPunCallbacks
{
    [SerializeField] Text roomtext;

    [SerializeField] string titletext;

    public void OnConnectRoom()
    {
        PhotonNetwork.JoinRoom(titletext);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        PanelManager.instance.Load(Panel.Error, message);
    }
    public void UpdateRoomInformation(RoomInfo roomInfo)
    {
        titletext = roomInfo.Name;

        roomtext.text = roomInfo.Name + " ( " + roomInfo.PlayerCount + " / " + roomInfo.MaxPlayers + " ) ";
       
    }
}
