using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Bounce bounce;
    public float maxSpeed = 10f;
    public Rigidbody rb;
    Vector3 moveVec;

    void Start() {
        CalculateMoveVec();
    }

    void FixedUpdate() {
        if (rb.velocity.magnitude > maxSpeed) {
            rb.AddForce(-moveVec * 0.1f, ForceMode.VelocityChange);
        } else {
            rb.AddForce(moveVec, ForceMode.VelocityChange);
        }
    }

    void OnCollisionEnter(Collision col) {
        Vector3 normalVec = col.contacts[0].normal;
        if (col.collider.tag == "Ground") {
            if(normalVec != Vector3.up) {
                bounce.BounceGO(normalVec);
                CalculateMoveVec();
            }
        } else {
            CalculateMoveVec();
        }
    }

    void CalculateMoveVec() {
        float maxSpeedComp = maxSpeed / Mathf.Sqrt(2);
        float xSpeed = Random.Range(-maxSpeedComp, maxSpeedComp);
        float zSpeed = Random.Range(-maxSpeedComp, maxSpeedComp);
        moveVec = new Vector3(xSpeed, 0f, zSpeed).normalized;
    }
    
}
