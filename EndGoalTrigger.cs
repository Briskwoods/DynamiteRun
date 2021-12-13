using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalTrigger : MonoBehaviour
{

    [SerializeField] private PlayConfetti playConfetti;
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag == "Player")
        {
            case true:
                playConfetti.BlastConfetti();
                CodeManager.Instance.PlayerAnimator_.SetBool("Win", true);
                CodeManager.Instance.PlayerMovement_.m_isStopped = true;
                CodeManager.Instance.PlayerMovement_.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case false:
                break;
        }
    }
}
