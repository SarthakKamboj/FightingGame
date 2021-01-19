using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public float maxVelocity = 100f;
    public float forceMultipler = 10f;
    public int maxJumps = 2;
    public Vector3 jumpForce;
    public float bounceMultipler = 10f;
    public Bounce bounce;
    float maxYVel = 10f;
    int jumpsLeft;
    float horizontal = 0f, vertical = 0f;
    bool shouldJump = false;

    void Start() {
        jumpsLeft = maxJumps;
    }

    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (!shouldJump) {
            shouldJump = Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0;
        }
    }

    void FixedUpdate() {
        Vector3 inputVec = new Vector3(horizontal, 0f, vertical);
        
        if (shouldJump) {
            rb.AddForce(jumpForce, ForceMode.VelocityChange);
            shouldJump = false;
            jumpsLeft -= 1;
            StartCoroutine(HandleStretchAndSquash());
        }

        if (Mathf.Abs(inputVec.magnitude) >= 0.1f) {
            float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y; 
            Vector3 forceDir = Quaternion.Euler(new Vector3(0f,angle,0f)) * Vector3.forward;
            if (rb.velocity.magnitude <= maxVelocity) {
                rb.AddForce(forceDir.normalized * forceMultipler * Time.deltaTime, ForceMode.VelocityChange);
            } else {
                // rb.velocity = rb.velocity.normalized * maxVelocity;
                rb.AddForce(-rb.velocity.normalized);
                // rb.AddForce(forceDir.normalized * forceMultipler * Time.deltaTime, ForceMode.VelocityChange);
            }
        }

    }

    void LateUpdate() {
        SetJumpStatus();
    }

    IEnumerator HandleStretchAndSquash() {
        yield return new WaitForSeconds(Time.fixedDeltaTime * 2f);
        maxYVel = rb.velocity.y * 1.5f;
    }

    void SetJumpStatus() {
        animator.SetFloat("JumpStatus", rb.velocity.y / maxYVel);
    }

    void OnCollisionEnter(Collision col) {
        Vector3 normalVec = col.contacts[0].normal;
        if (col.collider.tag == "Ground") {
            HandleGroundCol(normalVec);
        } else if (col.collider.tag == "Enemy") {
            bounce.BounceGO(normalVec);
        }
    }

    void HandleGroundCol(Vector3 normalVec) {
        if (normalVec == Vector3.up) {
            if (rb.velocity.y <= 0f) {
                jumpsLeft = maxJumps;
            }
        } else {
            bounce.BounceGO(normalVec);
        }
    }
    
}
