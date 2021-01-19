using UnityEngine;

public class InRange : MonoBehaviour
{
    public GameObject InRangeGO;
    bool inRange = false;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    public void GameObjectInRange() {
        inRange = true;
        InRangeGO.SetActive(inRange);
        if (rb) {
            rb.interpolation = RigidbodyInterpolation.Interpolate;
        }
    }

    void Update() {
        if (inRange) {
            InRangeGO.SetActive(false);
            inRange = false;
            if (rb) {
                rb.interpolation = RigidbodyInterpolation.None;
            }
        }
    }
}
