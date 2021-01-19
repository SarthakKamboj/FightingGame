using UnityEngine;

public class InRange : MonoBehaviour
{
    public GameObject InRangeGO;
    bool inRange = false;
    public void EnemyInRange() {
        inRange = true;
        InRangeGO.SetActive(inRange);
        GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update() {
        if (inRange) {
            InRangeGO.SetActive(false);
            inRange = false;
            GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.None;
        }
    }
}
