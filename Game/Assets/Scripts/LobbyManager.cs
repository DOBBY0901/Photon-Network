using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform parentTransform;
    [SerializeField] Dictionary<string, GameObject> dictionary = new();

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject prefab = null;

        foreach(RoomInfo roominfo in roomList)
        {
            //룸이 삭제된 경우

            if (roominfo.RemovedFromList == true)
            {
                dictionary.TryGetValue(roominfo.Name, out prefab);

                Destroy(prefab);

                dictionary.Remove(roominfo.Name);
            }
            else
            {
                //룸의 정보가 변경되는 경우
                if (dictionary.ContainsKey(roominfo.Name) == false)
                {
                    GameObject clone = Instantiate(Resources.Load<GameObject>("Room"), parentTransform);

                    clone.GetComponent<RoomView>().UpdateRoomInformation(roominfo);

                    dictionary.Add(roominfo.Name, clone);


                }
                else
                {
                    dictionary.TryGetValue(roominfo.Name, out prefab);
                    prefab.GetComponent<RoomView>().UpdateRoomInformation(roominfo);

                }
            }


        }
    }
}
