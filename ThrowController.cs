using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    [SerializeField] private float m_throwDelay = 1f;

    [SerializeField] private Transform m_throwPoint;

    [SerializeField] private float m_throwSpeed = 100f;
    [SerializeField] private float m_throwHeight = 100f;
    [SerializeField] private float m_throwTime = 2f;

    [SerializeField] private Rigidbody m_StickToThrow;


    private void Start()
    {
        m_throwPoint = CodeManager.Instance.ThrowPoint_;
        m_StickToThrow = CodeManager.Instance.StickToThrow_;
    }

    public void Throw()
    {
        switch(CodeManager.Instance.InventoryManager_.m_dynamiteStackSize > 0)
        {
            case true:
                CodeManager.Instance.PlayerAnimator_.SetTrigger("Throw");
                StartCoroutine(DelayAfterThrow(m_throwDelay));
                break;
            case false:
                break;
        }

        switch(CodeManager.Instance.InventoryManager_.m_dynamiteStackSize < 0)
        {
            case true:
                CodeManager.Instance.InventoryManager_.m_dynamiteStackSize = 0;
                break;
            case false:
                break;
        }
        //CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();
    }


    // Delay before throwing again Coroutine
    IEnumerator DelayAfterThrow(float seconds)
    {
        
        yield return new WaitForSeconds(seconds); // Slight Delay before throwing again        
        m_StickToThrow = Instantiate(m_StickToThrow, m_throwPoint.transform.position, m_throwPoint.transform.rotation); // Instantiate Stick to throw at hand position        
        m_StickToThrow.AddForce((m_StickToThrow.transform.forward + new Vector3(0, m_throwHeight, 0)) * m_throwSpeed * m_throwTime);// Add force in the Z direction (forward)        
        m_StickToThrow.AddRelativeTorque(new Vector3(1,1,1) * 10f , ForceMode.Impulse); //Add local rotation to the dynamite
        CodeManager.Instance.InventoryManager_.DisableSticksOnBack(); // Refresh number of sticks on back       
        CodeManager.Instance.InventoryManager_.m_dynamiteStackSize -= 1; // Reduce Stack Size     
        CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();   // Check stack size       
        m_StickToThrow = CodeManager.Instance.StickToThrow_; // Control Variable
    }
}
