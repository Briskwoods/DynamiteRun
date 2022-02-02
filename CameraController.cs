using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject m_player;
    [SerializeField] private Camera m_mainCamera;
    [SerializeField] float m_xPos = 0f;
    [SerializeField] float m_yPos;                            
    [SerializeField] float m_zPos;                             
    public CameraShakeScript m_shakeScript;
    public float CameraMaxXDirection;
    public float Percent;
    float MaxPlayer_X;

    public void Start()
    {
        MaxPlayer_X = m_player.GetComponent<PlayerMovement>().PlatformWidth;
    }

    public void Update()
    {
        switch (m_player != null)
        {
            case true:
                var playerpos = m_player.transform.position;
                playerpos.x = m_xPos;

                Percent = (m_player.transform.position.x/ MaxPlayer_X) * CameraMaxXDirection;

                m_mainCamera.transform.position = playerpos + new Vector3(Percent, m_yPos, -m_zPos);

                break;
            case false:
                break;
        }
    }
}
