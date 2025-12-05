using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;


public class MasterManager : MonoBehaviourPunCallbacks
{
    private WaitForSeconds waitForSeconds = new WaitForSeconds(5);

    public IEnumerator Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            while (true)
            {
                if (PhotonNetwork.CurrentRoom != null)
                {
                    PhotonNetwork.InstantiateRoomObject("Ball", Vector3.zero, Quaternion.identity);
                }

                yield return waitForSeconds;
            }
        }
    }

    IEnumerator SpawnRoutine()
    {
   
        yield return new WaitForSeconds(5);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
        Debug.Log(PhotonNetwork.PlayerList[0]); 
    }

   
}
