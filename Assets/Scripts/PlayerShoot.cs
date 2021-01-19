using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public LineRenderer shootRay;
    public float range = 10f;
    public float sensitivity = 0.25f;
    public float explosionImpact = 100f;
    public float upwardsModifier = 10f;
    float verticalMouseOffset = 0f;
    Vector3 aimVec;

    void Update() {
        verticalMouseOffset += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
    }

    void LateUpdate() {
        aimVec = GetAimVec();
        RenderLine();
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    Vector3 GetAimVec() {
        Vector3 forwardVec = Quaternion.Euler(new Vector3(0f, Camera.main.transform.eulerAngles.y, 0f)) * Vector3.forward;
        Vector3 rightVec = Vector3.Cross(Vector3.up, forwardVec);
        return Quaternion.AngleAxis(verticalMouseOffset, rightVec) * forwardVec;
    }
    
    void RenderLine() {
        Vector3[] positions = new Vector3[2] { transform.position, transform.position + aimVec.normalized * range };
        shootRay.SetPositions(positions);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, aimVec.normalized, out hit, range)) {
            Collider collider = hit.collider; 
            if (collider && collider.tag == "Enemy") {
                collider.gameObject.GetComponent<InRange>().EnemyInRange();
            }
        }
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
