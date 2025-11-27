using UnityEngine;
using Photon.Pun;

public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera;
    [SerializeField] CharacterController characterController;

    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    [SerializeField] Rotation rotation;
    private void Awake()
    {
        rotation.GetComponent<Rotation>();
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

            rotation.RotateY();
            
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

        //direction방향을 단위 벡터로 설정
        direction.Normalize();
        

    }

    public void Move()
    {
        characterController.Move(characterController.transform.TransformDirection(direction) * speed * Time.deltaTime);
    }
}

