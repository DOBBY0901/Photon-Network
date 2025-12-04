using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviourPunCallbacks
{
    

    public void Continue()
    {
        gameObject.SetActive(false);

        MouseManager.Instance.SetMouse(false);
    }

    public void Quit()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
}
