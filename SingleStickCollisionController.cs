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
                        CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();
                        CodeManager.Instance.UIManager_.SpawnUI(3, transform);
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
