using UnityEngine;

public class ForceField : MonoBehaviour
{
    
    public float shieldBounceMult = 10f;
    public GameObject player, ground;
    public Collider forceFieldCollider;

    void Start() {
        DisableCol(player.GetComponent<Collider>());
        foreach (Transform childTransform in ground.transform) {
            DisableCol(childTransform.GetComponent<Collider>());
        }
        gameObject.SetActive(false);
    }

    void DisableCol(Collider otherCollider) {
        Physics.IgnoreCollision(otherCollider, forceFieldCollider);
    }
    
}
