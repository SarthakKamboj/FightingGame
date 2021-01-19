using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationsPerSecond = 2f;
    Vector3 rotVec;

    void Start() {
        float degreesPerSecond = rotationsPerSecond * 360f;
        rotVec = new Vector3(0f, degreesPerSecond, 0f);
    }
    void FixedUpdate() {
        transform.rotation = Quaternion.Euler(rotVec * Time.fixedDeltaTime) * transform.rotation;
    }
}