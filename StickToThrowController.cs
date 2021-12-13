using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToThrowController : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    bool singleExplosion = false;
    public Vector3 Offset;

    [SerializeField] private float m_shakeTime = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.CompareTag("Debri") && !singleExplosion)
        {
            case true:

                singleExplosion = true;
                Blast();
                // Camera Shake Initialised Here
                CodeManager.Instance.CameraController_.m_shakeScript.enabled = true;
                CodeManager.Instance.CameraController_.m_shakeScript.ShakeNow(m_shakeTime);
                Destroy(gameObject);
                break;
            case false:
                break;
        }
    }

    public void Blast()
    {
        GameObject Obj = Instantiate(ExplosionPrefab);
        Obj.transform.position = transform.position - Offset;
    }
}
