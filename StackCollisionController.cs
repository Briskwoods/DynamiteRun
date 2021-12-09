using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.CompareTag("Player"))
        {
            case true:
                switch (CodeManager.Instance.InventoryManager_.m_dynamiteStackSize.Equals(0))
                {
                    case true:
                        CodeManager.Instance.InventoryManager_.m_dynamiteStackSize += 9;
                        CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();
                        Destroy(gameObject);
                        break;
                    case false:
                        break;
                }

                switch (CodeManager.Instance.InventoryManager_.m_dynamiteStackSize.Equals(1))
                {
                    case true:
                        CodeManager.Instance.InventoryManager_.m_dynamiteStackSize += 8;
                        CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();
                        Destroy(gameObject);
                        break;
                    case false:
                        break;
                }

                switch (CodeManager.Instance.InventoryManager_.m_dynamiteStackSize.Equals(2))
                {
                    case true:
                        CodeManager.Instance.InventoryManager_.m_dynamiteStackSize += 7;
                        CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();
                        Destroy(gameObject);
                        break;
                    case false:
                        break;
                }

                switch (CodeManager.Instance.InventoryManager_.m_dynamiteStackSize.Equals(3))
                {
                    case true:
                        CodeManager.Instance.InventoryManager_.m_dynamiteStackSize += 6;
                        CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();
                        Destroy(gameObject);
                        break;
                    case false:
                        break;
                }

                switch (CodeManager.Instance.InventoryManager_.m_dynamiteStackSize.Equals(4))
                {
                    case true:
                        CodeManager.Instance.InventoryManager_.m_dynamiteStackSize += 5;
                        CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();
                        Destroy(gameObject);
                        break;
                    case false:
                        break;
                }

                switch (CodeManager.Instance.InventoryManager_.m_dynamiteStackSize.Equals(5))
                {
                    case true:
                        CodeManager.Instance.InventoryManager_.m_dynamiteStackSize += 4;
                        CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();
                        Destroy(gameObject);
                        break;
                    case false:
                        break;
                }

                switch (CodeManager.Instance.InventoryManager_.m_dynamiteStackSize.Equals(6))
                {
                    case true:
                        CodeManager.Instance.InventoryManager_.m_dynamiteStackSize += 3;
                        CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();
                        Destroy(gameObject);
                        break;
                    case false:
                        break;
                }

                switch (CodeManager.Instance.InventoryManager_.m_dynamiteStackSize.Equals(7))
                {
                    case true:
                        CodeManager.Instance.InventoryManager_.m_dynamiteStackSize += 2;
                        CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();
                        Destroy(gameObject);
                        break;
                    case false:
                        break;
                }

                switch (CodeManager.Instance.InventoryManager_.m_dynamiteStackSize.Equals(8))
                {
                    case true:
                        CodeManager.Instance.InventoryManager_.m_dynamiteStackSize += 1;
                        CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();
                        Destroy(gameObject);
                        break;
                    case false:
                        break;
                }

                switch (CodeManager.Instance.InventoryManager_.m_dynamiteStackSize.Equals(9))
                {
                    case true:
                        CodeManager.Instance.InventoryManager_.CheckNumberOfSticks();
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
