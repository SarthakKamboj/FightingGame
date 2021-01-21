using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject menuScreen, optionsScreen;

    void Start() {
        menuScreen.SetActive(true);
        optionsScreen.SetActive(false);
    }

    public void GoToMenu() {
        menuScreen.SetActive(true);
        optionsScreen.SetActive(false);
    }

    public void GoToOptions() {
        menuScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }

}
