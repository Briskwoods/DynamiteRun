using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    [SerializeField] private Camera m_mainCamera;

    [SerializeField] float m_xPos = 0f;
    [SerializeField] float m_yPos;                              // Height from player
    [SerializeField] float m_zPos;                              // Distance From Player on Z axis


    void Start()
    {
        //InvokeRepeating("MoveCamera", 0.05f, 0.05f);
    }

    // Update is called once per frame
    public void Update()
    {
        var playerpos = m_player.transform.position;
        playerpos.x = m_xPos;
        m_mainCamera.transform.position = playerpos + new Vector3(m_xPos, m_yPos, -m_zPos);
    }
}
