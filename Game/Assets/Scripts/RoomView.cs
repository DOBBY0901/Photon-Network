using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomView : MonoBehaviourPunCallbacks
{
    [SerializeField] Text roomtext;

    [SerializeField] string titletext;

    [SerializeField] RoomInfo roominfo;

    [SerializeField] Button button;

    public event System.Action OnEntered;

    private void Start()
    {
        OnEntered += UpdateRoomStatus;
    }
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
        this.roominfo = roomInfo;

        titletext = roomInfo.Name;

        roomtext.text = roomInfo.Name + " ( " + roomInfo.PlayerCount + " / " + roomInfo.MaxPlayers + " ) ";

        OnEntered?.Invoke();
    }

   public void UpdateRoomStatus()
    {
        if (roominfo.IsOpen)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
        
    }

    private void OnDestroy()
    {
            OnEntered -= UpdateRoomStatus;
    }
}
