using UnityEngine;

public class ForceField : MonoBehaviour
{
    
    public float shieldBounceMult = 10f;
    public GameObject player, ground;
    public Collider forceFieldCollider;

    void Start() {
        DisableCol(player.GetComponent<Collider>());
        foreach (Transform childTransform in transform) {
            DisableCol(childTransform.GetComponent<Collider>());
        }
    }

    void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;
        Debug.Log(collider.tag);
        switch (collider.gameObject.tag) {
            case "Enemy":
                HandleEnemyCol(collider.gameObject, collider.attachedRigidbody);
                break;
            case "Player":
            case "Ground":
                DisableCol(collider);
                break;
        }
    }

    void DisableCol(Collider otherCollider) {
        Physics.IgnoreCollision(otherCollider, forceFieldCollider, true);
    }

    void HandleEnemyCol(GameObject gameObject, Rigidbody rb) {
        Debug.Log("hit enemy");
        // rb.velocity = Vector3.zero;
        // rb.angularVelocity = Vector3.zero;
        // gameObject.SetActive(false);
        
        // Vector3 forceDir = transform.position - gameObject.transform.position;
        // rb.AddForce(-forceDir * shieldBounceMult, ForceMode.VelocityChange);
        // Debug.Log("hit enemy");
    }
}
