using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public LineRenderer shootRay;
    public float range = 10f;
    public float sensitivity = 0.25f;
    public float explosionImpact = 100f;
    public float upwardsModifier = 10f;
    public LayerMask layerMask;
    float verticalMouseOffset = 0f;
    Vector3 aimVec;

    void Update() {
        verticalMouseOffset += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
    }

    void LateUpdate() {
        SetAimVec();
        RenderLine();
        ShowObjectsInSight();
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void SetAimVec() {
        Vector3 forwardVec = Quaternion.Euler(new Vector3(0f, Camera.main.transform.eulerAngles.y, 0f)) * Vector3.forward;
        Vector3 rightVec = Vector3.Cross(Vector3.up, forwardVec);
        aimVec = Quaternion.AngleAxis(verticalMouseOffset, rightVec) * forwardVec;
    }
    
    void RenderLine() {
        Vector3[] positions = new Vector3[2] { transform.position, transform.position + aimVec.normalized * range };
        shootRay.SetPositions(positions);
    }

    void ShowObjectsInSight() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, aimVec.normalized, out hit, range)) {
            Collider collider = hit.collider; 
            if (collider && LayerInLayerMask(collider.gameObject.layer)) {
                collider.gameObject.GetComponent<InRange>().GameObjectInRange();
            }
        }
    }

    bool LayerInLayerMask(int layer) {
        return (layerMask.value & (1 << layer)) > 0;
    }

    void Shoot() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, aimVec.normalized, out hit, range)) {
            Collider collider = hit.collider;
            if (collider && collider.tag == "Enemy") {
                Rigidbody goRb = hit.rigidbody;
                goRb.AddExplosionForce(explosionImpact, hit.point, collider.bounds.extents.x, upwardsModifier, ForceMode.VelocityChange);
            }
        }
    }

}
