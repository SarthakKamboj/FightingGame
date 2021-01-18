using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public LineRenderer shootRay;
    public float range = 10f;

    void LateUpdate() {

        // Debug.Log(Input.mousePosition);
        // Vector3 screenCenter = new Vector3(Screen.width/2, Screen.height/2, 0f);
        // Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        // Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        Vector3 forwardVec = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f) * Vector3.forward;
        Vector3[] positions = new Vector3[2] { transform.position, Vector3.zero };
        // Vector3[] positions = new Vector3[2] { transform.position, (forwardVec.normalized * range) + transform.position };
        shootRay.SetPositions(positions);
        /*
         if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
        */
    }
    
    void Shoot() {
        RaycastHit hit;
        Vector3 forwardVec = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f) * Vector3.forward;
        if (Physics.Raycast(transform.position, forwardVec.normalized, out hit, range)) {
            Debug.Log("hit");
        }
    }
}
