using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class SubscribePanel : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField usernameInputField;
    [SerializeField] InputField passwordInputField;
    [SerializeField] InputField addressInputField;

    public void Subscribe()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = addressInputField.text,
            Password = passwordInputField.text,
            Username = usernameInputField.text,
        };

        PlayFabClientAPI.RegisterPlayFabUser
        (
            request,
            Success,
            Failure
        );
    }

    public void Success(RegisterPlayFabUserResult registerPlayFabUserResult)
    {
        gameObject.SetActive( false );
    }


    public void Failure(PlayFabError playFabError)
    {
        var report = playFabError.GenerateErrorReport();
        var lines = report.Split("\n");
        
        PanelManager.instance.Load(Panel.Error, $"{lines[2]}\n{lines[3]}");
    
    }
}
