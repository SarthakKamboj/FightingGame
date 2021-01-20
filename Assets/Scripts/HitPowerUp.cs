using UnityEngine;

public class HitPowerUp : MonoBehaviour
{
    public LayerMask layerMask;
    public Score score;    

    void OnTriggerEnter(Collider collider) {
        if (IsPowerUp(collider.gameObject)) {
            Debug.Log("power up hit");
            score.scoreDecreaseMultiplier += 1;
        }
    }

    bool IsPowerUp(GameObject obj) {
        return (layerMask.value & (1 << obj.layer)) > 0;
    }
}
