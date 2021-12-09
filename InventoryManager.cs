using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int m_dynamiteStackSize = 0;

    [SerializeField] private GameObject m_stickInHand;
    [SerializeField] private List<GameObject> m_sticksOnBack = new List<GameObject>();

    private void Start()
    {
        CheckNumberOfSticks();
        m_sticksOnBack = CodeManager.Instance.StackOnBack_.m_sticksOnBack;
    }

    public void CheckNumberOfSticks()
    {
        switch (m_dynamiteStackSize > 0)
        {
            case true:
                // Hide Dynamite stick
                m_stickInHand.SetActive(true);
                // Set player animator to Run without stick
                CodeManager.Instance.PlayerAnimator_.SetBool("hasStick", true);
                EnableSticksOnBack();
                break;
            case false:
                // Show Dynamite stick
                m_stickInHand.SetActive(false);
                // Set player animator to run whilst holding stick
                CodeManager.Instance.PlayerAnimator_.SetBool("hasStick", false);
                break;
        }
    }

    public void EnableSticksOnBack()
    {
        switch (m_dynamiteStackSize > 1)
        {
            case true:
                for (int i = 1; i<m_dynamiteStackSize; i++)
                {
                    m_sticksOnBack[i].SetActive(true);
                }
                break;
            case false:
                break;
        }
    }

}
