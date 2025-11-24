using Photon.Pun;
using UnityEngine;

public class CreateManager : MonoBehaviourPunCallbacks
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      PhotonNetwork.Instantiate("Character", Vector3.zero, Quaternion.identity);
    }

   
}
