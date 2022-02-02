using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeManager : MonoBehaviour
{
    private static CodeManager _instance;
    public static CodeManager Instance { get { return _instance; } }

    public GameManager GameManager_;
    public InventoryManager InventoryManager_;
    public Animator PlayerAnimator_;
    public BackStackObjects StackOnBack_;
    public ThrowController ThrowController_;
    public Transform ThrowPoint_;
    public Rigidbody StickToThrow_;
    public CameraController CameraController_;
    public PlayerMovement PlayerMovement_;
    public EndGame EndGame_;
    public RunnerObjects RunnerObjects_;
    public UIManager UIManager_;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
