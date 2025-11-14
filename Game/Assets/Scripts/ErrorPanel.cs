using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ErrorPanel : MonoBehaviour
{
    [SerializeField] Text errortext;

    public void SetText(string message)
    {
        errortext.text = message;
    }
}
