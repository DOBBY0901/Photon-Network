using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Transform  content;
    [SerializeField] GameObject message;
    [SerializeField] ScrollRect scroll;

    bool isChatting;

    void Start()
    {
        inputField.onEndEdit.AddListener(InputChat);
        isChatting = false;
    }

    private void Update()
    {
        
    }

    void InputChat(string text)
    {
        if (!Input.GetKey(KeyCode.Return))
            return;

        Chat(text);

        inputField.text = "";
        
    }

    public void Chat(string text)
    {
        if (string.IsNullOrEmpty(text))
            return;

        GameObject messageobj = Instantiate(message, content);
        Text messageText = messageobj.GetComponent<Text>();
        messageText.text = text;

        if(scroll != null)
        {
            Canvas.ForceUpdateCanvases();
            scroll.verticalNormalizedPosition = 0f;
        }
    }
}
