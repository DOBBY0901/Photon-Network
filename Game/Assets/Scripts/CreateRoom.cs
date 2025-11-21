using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField titleInputField;
    
    [SerializeField] Button[] buttons;
    
    [SerializeField] int personal = 0;
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);

        buttons[0].onClick.Invoke();
    }
    public void OnCreateRoom()
    { 
        RoomOptions roomOptions = new RoomOptions(); 
        
        roomOptions.MaxPlayers = personal;
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(titleInputField.text, roomOptions);
    }

     public void Select(int count)
    {
        personal = count;
    }

    public void Cancle()
    {
        gameObject.SetActive(false);
    }
}

