using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DinoFracture;

public class StickToThrowController : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    bool singleExplosion = false;
    public Vector3 Offset;

    public float radius = 5.0F;
    public float power = 10.0F;

    public float Force = 2000f;
    public float UpForce = 2000f;

    public Material m_changecolour;

    bool bridge = false;

    [SerializeField] private float m_shakeTime = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Debri") && !singleExplosion && !collision.gameObject.GetComponent<PreFracturedGeometry>())
        {
            singleExplosion = true;
            Blast();
            // Camera Shake Initialised Here
            CodeManager.Instance.CameraController_.m_shakeScript.enabled = true;
            CodeManager.Instance.CameraController_.m_shakeScript.ShakeNow(m_shakeTime);
            Destroy(gameObject);



            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                RunnerController runner = hit.gameObject.GetComponent<RunnerController>();
                Animator animator = hit.gameObject.GetComponent<Animator>();

                if (rb != null && rb.gameObject.tag.Equals("Runner"))
                {
                    Rigidbody hip = hit.gameObject.GetComponent<HipObject>().m_hip;
                    SkinnedMeshRenderer mesh = hit.gameObject.GetComponent<RunnerMeshObject>().m_mesh;
                    runner.enabled = false;
                    animator.enabled = false;
                    //rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                    hip.AddExplosionForce(Force, hip.position, 10f, UpForce, ForceMode.Impulse);
                    mesh.material = m_changecolour;
                }
            }
        }
        else if (collision.collider.CompareTag("Debri") && collision.gameObject.GetComponent<PreFracturedGeometry>() && !singleExplosion)
        {
            singleExplosion = true;
            collision.gameObject.GetComponent<PreFracturedGeometry>().Fracture();
            bridge = true;
            Blast();

            foreach (Transform Tr in collision.gameObject.GetComponent<PreFracturedGeometry>().GeneratedPieces.transform)
            {
                Tr.GetComponent<Rigidbody>().AddExplosionForce(200, transform.position, 10f, 100f, ForceMode.Impulse);
            }
                        

            Destroy(gameObject);
        }
    }

    public void Blast()
    {
        GameObject Obj = Instantiate(ExplosionPrefab);
        Obj.transform.position = transform.position - Offset;

        if (bridge)
        { Obj.GetComponent<LocalExplosionManager>().DisableRim(); }
    }
}
