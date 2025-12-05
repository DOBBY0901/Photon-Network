using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField titleInputField;
    
    [SerializeField] Toggle [ ] toggles;      
    
    [SerializeField] int personal = 0;

    private void Start()
    {
        Select(true);
    }

    public void OnCreateRoom()
    { 
        RoomOptions roomOptions = new RoomOptions(); 
        
        roomOptions.MaxPlayers = personal;
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(titleInputField.text, roomOptions);

        gameObject.SetActive(false);
    }

     public void Select(bool power)
    {
       
        if (power == false)
        {
            return;
        }

        if (toggles[0].isOn)
        {
            personal = 2;
        }
        else if (toggles[1].isOn)
        {
            personal = 3;
        }
        else if (toggles[2].isOn)
        {
            personal = 4;
        }
    }

    public void Cancle()
    {
        gameObject.SetActive(false);
    }
}

