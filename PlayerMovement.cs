using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController m_playerController;
    [SerializeField] private Animator m_playerAnim;
    public bool IsPlayer;
    public CinemachineVirtualCamera CineCamera;
    
    public float m_speed = 150;
    public float m_initialSpeed;

    public float PlatformWidth = 2.7f;
    public float MaxFingerDistance = 250f;
    
    private Vector3 InitialPosition;

    private float DistanceFromCenter;
    private float Direction;
    private float Percent;
    private float XPos;
    public float percent;


    // Start is called before the first frame update
    void Start()
    {
        m_playerController = GetComponent<CharacterController>();
        m_initialSpeed = m_speed;
        m_playerAnim.SetBool("Run", true);
    }

    // Update is called once per frame
    void Update()
    {
        //m_playerController.Move(Vector3.forward * m_speed * Time.deltaTime);
        transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
        
        m_playerAnim.SetFloat("Speed", m_speed);

        //Evans - Update the camera field of view
        if (IsPlayer)
        {
            UpdateCameraDistance();
        }


        if (Input.GetMouseButtonDown(0))
        {
            InitialPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 IP = InitialPosition;
            Vector3 IMP = Input.mousePosition;
            IP.y = 0f;
            IMP.y = 0f;
            DistanceFromCenter = Vector3.Distance(IP, IMP);
            Direction = (IP - IMP).x;
            if (Direction > 0 && transform.position.x > -PlatformWidth)
            {
                //moving to the left
                Percent = (DistanceFromCenter / MaxFingerDistance);
                XPos = (-PlatformWidth * Percent);
            }
            else if (Direction < 0 && transform.position.x < PlatformWidth)
            {
                //Moving to the Right
                Percent = (DistanceFromCenter / MaxFingerDistance);
                XPos = (PlatformWidth * Percent);
            }
            else if (Direction < 0 && transform.position.x > PlatformWidth)
            {
                XPos = PlatformWidth;
            }
            else if (Direction > 0 && transform.position.x < -PlatformWidth)
            {
                XPos = -PlatformWidth;
            }
            else
            {
                XPos = transform.position.x;
            }
            if (XPos < PlatformWidth && XPos > -PlatformWidth)
            {
                transform.position = new Vector3(XPos, transform.position.y, transform.position.z);
            }
        }
    }

    public void UpdateCameraDistance()
    {
        float maxSpeed = 150f;
        float minSpeed = 50f;

         percent = ((m_speed - minSpeed) / (maxSpeed - minSpeed));
        
        float result = percent * 30f;

        CineCamera.m_Lens.FieldOfView = Mathf.Lerp(CineCamera.m_Lens.FieldOfView, 75f + result, 5f * Time.deltaTime);
    }
}
