using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    // Adjust the speed for the application.
    public float m_speed = 1.0f;
    public float m_initialSpeed = 0f;

    [SerializeField] private Animator m_runnerAnim;

    // The target (cylinder) position.
    public Transform target;

    void Start()
    {
        m_initialSpeed = m_speed;

        m_runnerAnim.SetBool("Run", true);
    }

    // Update is called once per frame
    void Update()
    {
        m_runnerAnim.SetFloat("Speed", m_speed);
        float step = m_speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
