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

    public void DisableSticksOnBack()
    {
        switch (m_dynamiteStackSize)
        {
            case 0:
                break;
            case 1:
                m_sticksOnBack[0].SetActive(false);
                break;
            case 2:
                m_sticksOnBack[1].SetActive(false);
                break;
            case 3:
                m_sticksOnBack[2].SetActive(false);
                break;
            case 4:
                m_sticksOnBack[3].SetActive(false);
                break;
            case 5:
                m_sticksOnBack[4].SetActive(false);
                break;
            case 6:
                m_sticksOnBack[5].SetActive(false);
                break;
            case 7:
                m_sticksOnBack[6].SetActive(false);
                break;
            case 8:
                m_sticksOnBack[7].SetActive(false);
                break;
            case 9:
                m_sticksOnBack[8].SetActive(false);
                break;
            case 10:
                m_sticksOnBack[9].SetActive(false);
                break;
        }
    }
}
