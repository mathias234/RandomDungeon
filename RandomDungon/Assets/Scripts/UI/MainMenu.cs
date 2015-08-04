using UnityEngine;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {
    public string mainLevel = "MainScene";

    public GameObject menuItems;
    public GameObject createOrLoadMenu;

    public List<GameObject> saveSlots;

    public bool newGame = false;

    // Menu Items
    public void LoadGameMenu() {
        Debug.Log("Load Game");
        newGame = false;
        menuItems.SetActive(false);
        createOrLoadMenu.SetActive(true);
    }
    public void NewGame() {
        Debug.Log("New Game");
        newGame = true;
        menuItems.SetActive(false);
        createOrLoadMenu.SetActive(true);
    }
    public void Options() {
        Debug.Log("Options");
    }
    public void Exit() {
        Debug.Log("Exit");
        Application.Quit();
    }


    // Load or create game menu
    public void SaveSlot(int id) {
        PlayerPrefs.SetInt("GameLoaded", id);
        Application.LoadLevel(mainLevel);
    }
    public void LoadOrCreateBack() {
        menuItems.SetActive(true);
        createOrLoadMenu.SetActive(false);
    }
}
