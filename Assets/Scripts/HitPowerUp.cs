using UnityEngine;

public class HitPowerUp : MonoBehaviour
{
    public LayerMask layerMask;
    public Score score;    

    void OnTriggerEnter(Collider collider) {
        if (IsPowerUp(collider.gameObject)) {
            score.scoreDecreaseMultiplier += 1;
            Destroy(collider.gameObject);
        }
    }

    bool IsPowerUp(GameObject obj) {
        return (layerMask.value & (1 << obj.layer)) > 0;
    }
}
