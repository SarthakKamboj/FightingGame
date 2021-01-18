using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Rigidbody rb;
    public float bounceMultipler;

    public void BounceGO(Vector3 normalVec) {
        rb.velocity = Vector3.Scale(Vector3.one - Abs(normalVec), rb.velocity);
        rb.angularVelocity = Vector3.Scale(Vector3.one - Abs(normalVec), rb.angularVelocity);
        rb.AddForce(normalVec * bounceMultipler, ForceMode.VelocityChange);
    }

    Vector3 Abs(Vector3 vec) {
        return new Vector3(Mathf.Abs(vec.x), Mathf.Abs(vec.y), Mathf.Abs(vec.z));
    }
    
}
