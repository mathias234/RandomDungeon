using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;

public class UIManager : MonoBehaviour {

    enum MenuStates {
        MainMenu,
        OptionsMenu,
        ExtrasMenu,
        CreditsMenu
    };

    [Header("Main Menu")]
    public GameObject[] Menus;

    [Header("Options")]
    //public Slider volSlider;
    public int Quality = 3;

    public void Awake() {
        ChangeMenu(MenuStates.MainMenu);
    }

    public void ChangeScene(int sceneToChangeTo) {
        Application.LoadLevel(sceneToChangeTo);
    }
    public void LoadWebsite(string Website) {
        Application.OpenURL(Website);
    }
    public void ExitApp() {
        Application.Quit();
    }

    /*
     * Menu Navigation Declairation
    */

    public void MainMenu() {
        ChangeMenu(MenuStates.MainMenu);
    }

    public void OptionsMenu() {
        ChangeMenu(MenuStates.OptionsMenu);
    }

    public void ExtrasMenu() {
        ChangeMenu(MenuStates.ExtrasMenu);
    }

    public void CreditsMenu() {
        ChangeMenu(MenuStates.CreditsMenu);
    }

    void ChangeMenu(MenuStates t_state) {
        switch (t_state) {
            case MenuStates.MainMenu:
                Menus[0].SetActive(true);
                Menus[1].SetActive(false);
                Menus[2].SetActive(false);
                Menus[3].SetActive(false);
                break;

            case MenuStates.OptionsMenu:
                Menus[0].SetActive(false);
                Menus[1].SetActive(true);
                Menus[2].SetActive(false);
                Menus[3].SetActive(false);
                break;

            case MenuStates.ExtrasMenu:
                Menus[0].SetActive(false);
                Menus[1].SetActive(false);
                Menus[2].SetActive(true);
                Menus[3].SetActive(false);
                break;

            case MenuStates.CreditsMenu:
                Menus[0].SetActive(false);
                Menus[1].SetActive(false);
                Menus[2].SetActive(false);
                Menus[3].SetActive(true);
                break;
        }
    }

    public void MinimiseWindow() {

    }

    public void OpenApplication(string applicationPath) {
        Process myProcess = new Process();
        myProcess.StartInfo.FileName = applicationPath;
        myProcess.Start();
        ExitApp();
    }
}