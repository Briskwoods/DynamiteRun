using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    public void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    public void ShakeNow(float ShakeInt)
    {
        shakeDuration = ShakeInt;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = transform.localPosition + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
    }
}