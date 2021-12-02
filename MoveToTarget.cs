using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{

    public Transform target; 
    [SerializeField] private int m_moveSpeed = 100;


    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * m_moveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * m_moveSpeed * Time.deltaTime);
    }

}
