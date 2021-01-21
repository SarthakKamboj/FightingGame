using System.Collections;
using UnityEngine;

public class ClickedLeftMouseBtn : MonoBehaviour
{
    public TutorialManager tutorialManager;
    public GameObject enemy;
    public bool enemyShouldBeStatic;


    void Awake() {
        enemy.SetActive(false);
        transform.parent.gameObject.SetActive(false);
    }

    void OnEnable() {
        enemy.SetActive(true);
        enemy.GetComponent<EnemyMovement>().enabled = !enemyShouldBeStatic;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            StartCoroutine(HandleLeftClick());
        }
    }

    IEnumerator HandleLeftClick() {
        yield return new WaitForSeconds(2 * Time.fixedDeltaTime);
        if (enemy == null) {
            tutorialManager.MoveOnToNextTutSection();
        }
    }
}
