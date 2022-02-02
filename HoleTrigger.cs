using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag.Equals("Player"))
        {
            CodeManager.Instance.PlayerMovement_.m_isStopped = true;
            CodeManager.Instance.PlayerAnimator_.SetBool("Trip", true);
            CodeManager.Instance.CameraController_.enabled = false;
            CodeManager.Instance.CameraController_.m_player = null;
            CodeManager.Instance.PlayerMovement_.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            CodeManager.Instance.PlayerMovement_.gameObject.GetComponent<DisableUI>().DisableNow();
            CodeManager.Instance.UIManager_.UiEnd();
        }
        else if(collider.tag.Equals("Runner"))
        {
            collider.GetComponent<RunnerController>().m_speed = 10;
            collider.GetComponent<Animator>().SetBool("Trip", true);
            collider.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
