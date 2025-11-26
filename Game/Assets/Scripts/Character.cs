using UnityEngine;
using Photon.Pun;

public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera;
    [SerializeField] CharacterController characterController;

    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        DisableCamera();
    }

    private void Update()
    {
        if(photonView.IsMine)
        {
            Control();
            Move();
        }
        
    }

    public void DisableCamera()
    {
        if (photonView.IsMine)
        {
            Camera maincamera = Camera.main;
            maincamera.gameObject.SetActive(false);

            remoteCamera.gameObject.SetActive(true);
        }
        else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }

    public void Control()
    {

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        direction.Normalize();
        

    }

    public void Move()
    {
        characterController.Move(direction * speed * Time.deltaTime);
    }
}

