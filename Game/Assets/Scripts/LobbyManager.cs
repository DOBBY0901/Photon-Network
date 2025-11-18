using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Dictionary<string, GameObject> dictionary = new();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject prefab = null;
    }
}
