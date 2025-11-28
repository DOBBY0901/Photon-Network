using Photon.Pun;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mouse : MonoBehaviourPunCallbacks
{
    public void SetMouse(bool state)
    {
        Cursor.visible = state;

        Cursor.lockState = (CursorLockMode)Convert.ToInt32(state);
    }

    private void OnDestroy()
    {
        if(photonView.IsMine)
        {
            SetMouse(true);
        }
    }
}
