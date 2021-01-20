using UnityEngine;

public class SpeedUpPowerUp : MonoBehaviour
{

    public float speedMultiplier = 2f;

    void Start() {
        transform.rotation = Quaternion.Euler(new Vector3(0f,0f,90f)) * transform.rotation;
    }

}
