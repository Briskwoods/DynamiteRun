using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStickCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.CompareTag("Player"))
        {
            case true:
                switch (CodeManager.Instance.InventoryManager_.m_dynamiteStackSize < 9)
                {
                    case true:
                        CodeManager.Instance.InventoryManager_.m_dynamiteStackSize += 1;
                        Debug.Log(CodeManager.Instance.InventoryManager_.m_dynamiteStackSize);
                        CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();
                        Destroy(gameObject);
                        break;
                    case false:
                        break;
                }
                break;
            case false:
                break;
        }
    }
}
