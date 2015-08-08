using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UIManager : MonoBehaviour {
    public GameObject corsair;
    public GameObject playerPanel;
    public Text itemInfo;
    public RigidbodyFirstPersonController controller;

    public RectTransform WeaponUpgradeSlot1;
    public RectTransform WeaponUpgradeSlot2;
    public RectTransform Head;
    public RectTransform Chest;
    public RectTransform Legs;
    public RectTransform Hands;

    public static UIManager instance;

    public void Awake() {
        instance = this;
    }
    public void Start() {
        SetupPlayerUI();

    }

    public void Update() {
        HandleKeypress();
    }

    void SetupPlayerUI() {
        corsair = GameObject.Find("Corsair");
        playerPanel = GameObject.Find("PlayerPanel");
        controller = gameObject.GetComponent<RigidbodyFirstPersonController>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        corsair.SetActive(true);
        playerPanel.SetActive(false);
        controller.enabled = true;
    }

    void HandleKeypress() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (Cursor.lockState == CursorLockMode.None) {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                corsair.SetActive(true);
                playerPanel.SetActive(false);
                controller.enabled = true;
            }
            else {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                corsair.SetActive(false);
                playerPanel.SetActive(true);
                controller.enabled = false;

            }
        }
    }

    public void ChangeArmorSlot(Armor.ArmorSlots slot, Sprite sprite) {
        if (slot == Armor.ArmorSlots.Chestpiece) {
            Image invIcon = Chest.FindChild("Foreground").GetComponent<Image>();
            invIcon.sprite = sprite;
        }
        else if (slot == Armor.ArmorSlots.Hands) {
            Image invIcon = Hands.FindChild("Foreground").GetComponent<Image>();
            invIcon.sprite = sprite;
        }
        else if (slot == Armor.ArmorSlots.Legs) {
            Image invIcon = Legs.FindChild("Foreground").GetComponent<Image>();
            invIcon.sprite = sprite;
        }
        else if (slot == Armor.ArmorSlots.Headguard) {
            Image invIcon = Head.FindChild("Foreground").GetComponent<Image>();
            invIcon.sprite = sprite;
        }
    }

    public void ChangeWeaponSlot(String slot, Sprite sprite) {
        if (slot == "WeaponSlot1") {
            Image invIcon = WeaponUpgradeSlot1.FindChild("Foreground").GetComponent<Image>();
            invIcon.sprite = sprite;
        }
        else if (slot == "WeaponSlot2") {
            Image invIcon = WeaponUpgradeSlot2.FindChild("Foreground").GetComponent<Image>();
            invIcon.sprite = sprite;
        }
    }

    // clear this spot and add it to the inventory
    public void ClearEquipmentSlot(string type) {
        if (type == "Head") {
            Head.FindChild("Foreground").GetComponent<Image>().sprite = new Sprite();
        }
        else if (type == "Chest") {
            Chest.FindChild("Foreground").GetComponent<Image>().sprite = new Sprite();
        }
        else if (type == "Legs") {
            Legs.FindChild("Foreground").GetComponent<Image>().sprite = new Sprite();
        }
        else if (type == "Hands") {
            Hands.FindChild("Foreground").GetComponent<Image>().sprite = new Sprite();
        }
        else if (type == "WeaponSlot1") {
            WeaponUpgradeSlot1.FindChild("Foreground").GetComponent<Image>().sprite = new Sprite();
        }
        else if (type == "WeaponSlot2") {
            WeaponUpgradeSlot2.FindChild("Foreground").GetComponent<Image>().sprite = new Sprite();
        }

    }
}
