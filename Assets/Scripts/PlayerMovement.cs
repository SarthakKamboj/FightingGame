using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forceMultipler = 10f;
    public int maxJumps = 2;
    public Vector3 jumpForce;
    public float bounceMultipler = 10f;
    public Bounce bounce;

    int jumpsLeft;
    float horizontal = 0f, vertical = 0f;
    bool shouldJump = false;

    void Start() {
        jumpsLeft = maxJumps;
    }

    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        shouldJump = Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0;

         if (shouldJump) {
            rb.AddForce(jumpForce, ForceMode.VelocityChange);
            jumpsLeft -= 1;
            shouldJump = false;
        }
    }

    void FixedUpdate() {
        Vector3 inputVec = new Vector3(horizontal, 0f, vertical);
        if (Mathf.Abs(inputVec.magnitude) >= 0.1f) {
            float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y; 
            Vector3 forceDir = Quaternion.Euler(new Vector3(0f,angle,0f)) * Vector3.forward;
            rb.AddForce(forceDir.normalized * forceMultipler * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    void OnCollisionEnter(Collision col) {
        Vector3 normalVec = col.contacts[0].normal;
        if (col.collider.tag == "Ground") {
            if(normalVec == Vector3.up) {
                jumpsLeft = maxJumps;
            } else {
                bounce.BounceGO(normalVec);
            }
        } else if (col.collider.tag == "Enemy") {
            bounce.BounceGO(normalVec);
        }
    }

    
}
