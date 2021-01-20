using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject forceField;
    [SerializeField]
    float shieldDuration;

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "ShieldPowerUp") {
            forceField.SetActive(true);
            StartCoroutine(DisableForceField());
        }
    }

    IEnumerator DisableForceField() {
        yield return new WaitForSeconds(shieldDuration);
        forceField.SetActive(false);
    }
}
