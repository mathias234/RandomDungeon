using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

namespace RandomDungeon {
    public class UIManager : MonoBehaviour {
        public GameObject crosshair;
        public GameObject playerPanel;
        public Text itemInfo;
        public RigidbodyFirstPersonController controller;

        public RectTransform Upgrade1;
        public RectTransform Upgrade2;
        public RectTransform Head;
        public RectTransform Chest;
        public RectTransform Legs;
        public RectTransform Hands;

        public static UIManager instance;

        public Sprite NoItem;

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
            crosshair = GameObject.Find("Crosshair");
            playerPanel = GameObject.Find("PlayerPanel");
            controller = gameObject.GetComponent<RigidbodyFirstPersonController>();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            crosshair.SetActive(true);
            playerPanel.SetActive(false);
            controller.enabled = true;
        }

        void HandleKeypress() {
            if (Input.GetKeyDown(KeyCode.Tab)) {
                if (Cursor.lockState == CursorLockMode.None) {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    crosshair.SetActive(true);
                    playerPanel.SetActive(false);
                    controller.enabled = true;
                    PlayerStats.instance.inMenu = false;
                }
                else {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    crosshair.SetActive(false);
                    playerPanel.SetActive(true);
                    controller.enabled = false;
                    PlayerStats.instance.inMenu = true;
                }
            }
        }

        public void ChangeArmorSlot(Items.Armor.ArmorSlots slot, Sprite sprite) {
            if (slot == Items.Armor.ArmorSlots.Chestpiece) {
                Image invIcon = Chest.FindChild("Foreground").GetComponent<Image>();
                invIcon.sprite = sprite;
            }
            else if (slot == Items.Armor.ArmorSlots.Hands) {
                Image invIcon = Hands.FindChild("Foreground").GetComponent<Image>();
                invIcon.sprite = sprite;
            }
            else if (slot == Items.Armor.ArmorSlots.Legs) {
                Image invIcon = Legs.FindChild("Foreground").GetComponent<Image>();
                invIcon.sprite = sprite;
            }
            else if (slot == Items.Armor.ArmorSlots.Headguard) {
                Image invIcon = Head.FindChild("Foreground").GetComponent<Image>();
                invIcon.sprite = sprite;
            }
        }

        public void ChangeWeaponSlot(String slot, Sprite sprite) {
            if (slot == "WeaponSlot1") {
                Image invIcon = Upgrade1.FindChild("Foreground").GetComponent<Image>();
                invIcon.sprite = sprite;
            }
            else if (slot == "WeaponSlot2") {
                Image invIcon = Upgrade2.FindChild("Foreground").GetComponent<Image>();
                invIcon.sprite = sprite;
            }
        }

        public void SetItemInfo(string text) {
            itemInfo.text = text;
        }
        // clear this spot and add it to the inventory
        public void ClearEquipmentSlot(EquipmentType type) {
            if (type == EquipmentType.Head) {
                Head.FindChild("Foreground").GetComponent<Image>().sprite = NoItem;
            }
            else if (type == EquipmentType.Chest) {
                Chest.FindChild("Foreground").GetComponent<Image>().sprite = NoItem;
            }
            else if (type == EquipmentType.Legs) {
                Legs.FindChild("Foreground").GetComponent<Image>().sprite = NoItem;
            }
            else if (type == EquipmentType.Hands) {
                Hands.FindChild("Foreground").GetComponent<Image>().sprite = NoItem;
            }
            else if (type == EquipmentType.Upgrade1) {
                Upgrade1.FindChild("Foreground").GetComponent<Image>().sprite = NoItem;
            }
            else if (type == EquipmentType.Upgrade2) {
                Upgrade2.FindChild("Foreground").GetComponent<Image>().sprite = NoItem;
            }

        }
    }
}