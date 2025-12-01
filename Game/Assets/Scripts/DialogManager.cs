using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] Transform  parentTransform;
    [SerializeField] ScrollRect scrollRect;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if (inputField.text.Length <= 0)
            {
                return;
            }

            string talk = inputField.text;
            
            //RPCTaeget.All 현재 룸의 모든 클라이언트에게 Talk함수 실행 명령

            photonView.RPC("Send", RpcTarget.All, talk);

            //텍스트 초기화
            inputField.text = "";

            //채팅 입력후에도 이어서 입력할수있도록
            inputField.ActivateInputField();

            //Canvas를 수동으로 동기화
            Canvas.ForceUpdateCanvases();

            //스크롤 위치를 초기화합니다.
            scrollRect.verticalNormalizedPosition = 0f;
        }
    }

    [PunRPC]
    public void Send(string message)
    {
        GameObject talk = Instantiate(Resources.Load<GameObject>("Talk"));
        
        talk.GetComponent<Text>().text = message;

        talk.transform.SetParent(parentTransform, false);
    }
}
