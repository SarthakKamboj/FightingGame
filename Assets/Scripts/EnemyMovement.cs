using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Bounce bounce;
    public float maxSpeed = 10f;
    public Rigidbody rb;
    public int damage;
    Vector3 moveVec;

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
            HandleGroundCol(normalVec);
        } else if (col.collider.tag == "Player") {
            HandlePlayerCol(col.collider.gameObject);
        }

        GenNewMoveVec();
    }


    void HandleGroundCol(Vector3 normalVec) {
        if(normalVec != Vector3.up) {
            bounce.BounceGO(normalVec);
        }
    }

    void HandlePlayerCol(GameObject player) {
        player.GetComponent<Health>().TakeDamage(damage);
    }

    void GenNewMoveVec() {
        float maxSpeedComp = maxSpeed / Mathf.Sqrt(2);
        float xSpeed = Random.Range(-maxSpeedComp, maxSpeedComp);
        float zSpeed = Random.Range(-maxSpeedComp, maxSpeedComp);
        moveVec = new Vector3(xSpeed, 0f, zSpeed).normalized;
    }
    
}
