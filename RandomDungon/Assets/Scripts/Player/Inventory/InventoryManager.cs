using UnityEngine;
using System.Collections.Generic;
using RandomDungeon.GameMap;

namespace RandomDungeon.Items {

    // This class is big.. should maybe be split up?
    public class InventoryManager : MonoBehaviour {
        public List<Item> inventory = new List<Item>();

        public Weapon Upgrade1;
        public Weapon Upgrade2;
        public Armor Head;
        public Armor Chest;
        public Armor Legs;
        public Armor Hands;

        public List<string> weaponNames = new List<string>();
        public List<string> armorNames = new List<string>();

        UIManager uiManager;

        public static InventoryManager instance;

        public GameObject itemButton;
        public Transform contentPanel;

        public float currentWeight;
        public float maxWeight = 10;

        void Awake() {
            instance = this;
            uiManager = GetComponent<UIManager>();

        }

        void Start() {


            DrawInventory();
        }

        void Update() {
            currentWeight = 0;
            foreach (var i in inventory) {
                currentWeight += i.weight;
            }
            if (currentWeight >= maxWeight) {
            }
        }

        // Generate a random item.
        public Item GenerateRandomItem() {
            Sprites s = Sprites.i;
            int rnd = Random.Range(0, 2);
            if (rnd == 0) {
                // Create a weapon
                Weapon newItem = new Weapon();
                newItem = new Weapon();
                newItem.name = weaponNames[Random.Range(0, weaponNames.Count)];
                newItem.maxDurability = Random.Range(50, 200);
                newItem.durability = newItem.maxDurability;
                newItem.stats = new Stats(Random.Range(1, 20 * Map.mapLevel), Random.Range(1, 20 * Map.mapLevel), Random.Range(1, 20 * Map.mapLevel), Random.Range(1, 20 * Map.mapLevel));
                newItem.weight = Random.Range(0.5f, 2.5f);
                newItem.sprite = s.weaponSprites[Random.Range(0, s.weaponSprites.Count)];

                // Currently we only have Damage Upgrade
                newItem.slot = Weapon.WeaponUpgrade.Damage;

                if (newItem.slot == Weapon.WeaponUpgrade.Damage) {
                    newItem.DamageMultiplier = Random.Range(1f, 3f);
                }
                return newItem;

            }
            else if (rnd == 1) {
                // Create a armor piece
                Armor newItem = new Armor();
                newItem = new Armor();
                newItem.name = armorNames[Random.Range(0, armorNames.Count)];
                newItem.maxDurability = Random.Range(50, 200);
                newItem.stats = new Stats(Random.Range(1, 20 * Map.mapLevel), Random.Range(1, 20 * Map.mapLevel), Random.Range(1, 20 * Map.mapLevel), Random.Range(1, 20 * Map.mapLevel));
                newItem.slot = (Armor.ArmorSlots)Random.Range(0, 4);

                // Assign a sprite that matches the armor type
                if (newItem.slot == Armor.ArmorSlots.Chestpiece)
                    newItem.sprite = s.chestSprites[Random.Range(0, s.chestSprites.Count)];
                else if (newItem.slot == Armor.ArmorSlots.Hands)
                    newItem.sprite = s.handsSprites[Random.Range(0, s.handsSprites.Count)];
                else if (newItem.slot == Armor.ArmorSlots.Headguard)
                    newItem.sprite = s.headSprites[Random.Range(0, s.headSprites.Count)];
                else if (newItem.slot == Armor.ArmorSlots.Legs)
                    newItem.sprite = s.legsSprites[Random.Range(0, s.legsSprites.Count)];


                return newItem;
            }
            else if (rnd == 2) {
                // Create junk
                // Junk is not implemented in this game
            }

            return new Item();
        }

        /// <summary>
        /// Equip the item
        /// </summary>
        /// <param name="item"> the item you want to equip</param>
        public void EquipItem(Item item) {
            if (CanEquipItem(item) == false)
                return;

            if (item is Weapon) {
                Weapon weapon = (Weapon)item;
                EquipWeapon(weapon);
            }

            else if (item is Armor) {
                Armor armor = (Armor)item;
                EquipArmor(armor);
            }
        }

        // Returns true if we can equip the item if not return false
        public bool CanEquipItem(Item item) {
            return true;
        }

        // Equip a weapon
        public void EquipWeapon(Weapon item) {
            if (Upgrade1 == null) {
                Upgrade1 = item;
                uiManager.ChangeWeaponSlot("WeaponSlot1", item.sprite);
                PlayerStats.instance.statModifiers.Add(item.stats);
                RemoveItemFromInventory(item);
            }
            else if (Upgrade2 == null) {
                Upgrade2 = item;
                uiManager.ChangeWeaponSlot("WeaponSlot2", item.sprite);
                PlayerStats.instance.statModifiers.Add(item.stats);
                RemoveItemFromInventory(item);
            }

            else if (Upgrade1 != null && Upgrade2 != null) {

            }
            DrawInventory();
        }

        // Equip a armor piece
        public void EquipArmor(Armor item) {
            PlayerStats.instance.statModifiers.Add(item.stats);
            if (item.slot == Armor.ArmorSlots.Chestpiece) {
                if (Chest != null) {
                    AddItem(Chest);
                    PlayerStats.instance.statModifiers.Remove(Chest.stats);
                }

                Chest = item;
                uiManager.ChangeArmorSlot(Armor.ArmorSlots.Chestpiece, item.sprite);
                RemoveItemFromInventory(item);
            }
            else if (item.slot == Armor.ArmorSlots.Hands) {
                if (Hands != null) {
                    AddItem(Hands);
                    PlayerStats.instance.statModifiers.Remove(Hands.stats);

                }

                Hands = item;
                uiManager.ChangeArmorSlot(Armor.ArmorSlots.Hands, item.sprite);
                RemoveItemFromInventory(item);
            }
            else if (item.slot == Armor.ArmorSlots.Legs) {
                if (Legs != null) {
                    AddItem(Legs);
                    PlayerStats.instance.statModifiers.Remove(Legs.stats);
                }

                Legs = item;
                uiManager.ChangeArmorSlot(Armor.ArmorSlots.Legs, item.sprite);
                RemoveItemFromInventory(item);
            }
            else if (item.slot == Armor.ArmorSlots.Headguard) {
                if (Head != null) {
                    AddItem(Head);
                    PlayerStats.instance.statModifiers.Remove(Head.stats);
                }

                Head = item;
                uiManager.ChangeArmorSlot(Armor.ArmorSlots.Headguard, item.sprite);
                RemoveItemFromInventory(item);
            }
            DrawInventory();
        }

        /// <summary>
        /// clear this spot and add it to the inventory
        /// </summary>
        /// <param name="type">Slot type: Head, Chest, Hands, Legs, WeaponSlot1, WeaponSlot2</param>
        public void EquipmentClicked(EquipmentType type) {
            if (type == EquipmentType.Head && Head != null) {
                AddItem(Head);
                PlayerStats.instance.statModifiers.Remove(Head.stats);
                Head = null;
            }
            else if (type == EquipmentType.Chest && Chest != null) {
                PlayerStats.instance.statModifiers.Remove(Chest.stats);
                AddItem(Chest);
                Chest = null;
            }
            else if (type == EquipmentType.Legs && Legs != null) {
                PlayerStats.instance.statModifiers.Remove(Legs.stats);
                AddItem(Legs);
                Legs = null;
            }
            else if (type == EquipmentType.Hands && Hands != null) {
                PlayerStats.instance.statModifiers.Remove(Hands.stats);
                AddItem(Hands);
                Hands = null;
            }
            else if (type == EquipmentType.Upgrade1 && Upgrade1 != null) {
                PlayerStats.instance.statModifiers.Remove(Upgrade1.stats);
                AddItem(Upgrade1);
                Upgrade1 = null;
            }
            else if (type == EquipmentType.Upgrade2 && Upgrade2 != null) {
                PlayerStats.instance.statModifiers.Remove(Upgrade2.stats);
                AddItem(Upgrade2);
                Upgrade2 = null;
            }
            DrawInventory();
            UIManager.instance.ClearEquipmentSlot(type);

        }

        public void ShowTooltip(Item item) {
            if (item is Weapon) {
                Weapon weapon = (Weapon)item;
                uiManager.SetItemInfo(
                        "<b><i>" + weapon.name + "</i></b>      " +
                        weapon.slot + "\n" +
                        "DamageMultiplier: " + weapon.DamageMultiplier.ToString() + "\n" +
                        "Stamina: " + weapon.stats.stamina.ToString() + "\n" +
                        "Strength: " + weapon.stats.strength.ToString() + "\n" +
                        "Intelligence: " + weapon.stats.intellect.ToString() + "\n" +
                        "Agility: " + weapon.stats.agility.ToString()
                    );
            }
            else if (item is Armor) {
                Armor armor = (Armor)item;
                uiManager.SetItemInfo(
                        "<b><i>" + armor.slot + " " + item.name + "</i></b>\n" +
                        "Stamina: " + armor.stats.stamina.ToString() + "\n" +
                        "Strength: " + armor.stats.strength.ToString() + "\n" +
                        "Intelligence: " + armor.stats.intellect.ToString() + "\n" +
                        "Agility: " + armor.stats.agility.ToString()
                    );
            }
        }

        public void ShowTooltip(EquipmentType type) {
            if (type == EquipmentType.Head && Head != null) {
                uiManager.SetItemInfo(
                        "<b><i>" + Head.slot + " " + Head.name + "</i></b>\n" +
                        "Stamina: " + Head.stats.stamina.ToString() + "\n" +
                        "Strength: " + Head.stats.strength.ToString() + "\n" +
                        "Intelligence: " + Head.stats.intellect.ToString() + "\n" +
                        "Agility: " + Head.stats.agility.ToString()
                    );
            }
            else if (type == EquipmentType.Chest && Chest != null) {
                uiManager.SetItemInfo(
                        "<b><i>" + Chest.slot + " " + Chest.name + "</i></b>\n" +
                        "Stamina: " + Chest.stats.stamina.ToString() + "\n" +
                        "Strength: " + Chest.stats.strength.ToString() + "\n" +
                        "Intelligence: " + Chest.stats.intellect.ToString() + "\n" +
                        "Agility: " + Chest.stats.agility.ToString()
                    );
            }
            else if (type == EquipmentType.Legs && Legs != null) {
                uiManager.SetItemInfo(
                        "<b><i>" + Legs.slot + " " + Legs.name + "</i></b>\n" +
                        "Stamina: " + Legs.stats.stamina.ToString() + "\n" +
                        "Strength: " + Legs.stats.strength.ToString() + "\n" +
                        "Intelligence: " + Legs.stats.intellect.ToString() + "\n" +
                        "Agility: " + Legs.stats.agility.ToString()
                    );
            }
            else if (type == EquipmentType.Hands && Hands != null) {
                uiManager.SetItemInfo(
                        "<b><i>" + Hands.slot + " " + Hands.name + "</i></b>\n" +
                        "Stamina: " + Hands.stats.stamina.ToString() + "\n" +
                        "Strength: " + Hands.stats.strength.ToString() + "\n" +
                        "Intelligence: " + Hands.stats.intellect.ToString() + "\n" +
                        "Agility: " + Hands.stats.agility.ToString()
                    );
            }
            else if (type == EquipmentType.Upgrade1 && Upgrade1 != null) {
                uiManager.SetItemInfo(
                        "<b><i>" + Upgrade1.name + "</i></b>      " +
                        Upgrade1.slot + "\n" +
                        "DamageMultiplier: " + Upgrade1.DamageMultiplier.ToString() + "\n" +
                        "Stamina: " + Upgrade1.stats.stamina.ToString() + "\n" +
                        "Strength: " + Upgrade1.stats.strength.ToString() + "\n" +
                        "Intelligence: " + Upgrade1.stats.intellect.ToString() + "\n" +
                        "Agility: " + Upgrade1.stats.agility.ToString()
                    );
            }
            else if (type == EquipmentType.Upgrade2 && Upgrade2 != null) {
                uiManager.SetItemInfo(
                        "<b><i>" + Upgrade2.name + "</i></b>      " +
                        Upgrade2.slot + "\n" +
                        "DamageMultiplier: " + Upgrade2.DamageMultiplier.ToString() + "\n" +
                        "Stamina: " + Upgrade2.stats.stamina.ToString() + "\n" +
                        "Strength: " + Upgrade2.stats.strength.ToString() + "\n" +
                        "Intelligence: " + Upgrade2.stats.intellect.ToString() + "\n" +
                        "Agility: " + Upgrade2.stats.agility.ToString()
                    );
            }
            else if (type == EquipmentType.None) {
                uiManager.SetItemInfo("");
            }
            DrawInventory();
        }

        public void AddItem(Item item) {
            //item.inventorySlot = invSlot;
            inventory.Add(item);

            // Redraw the inventory
            DrawInventory();
        }

        public void RemoveItemFromInventory(Item item) {
            inventory.Remove(item);
            DrawInventory();
        }

        void PopulateInventory() {
            foreach (var item in inventory) {
                GameObject newButton = Instantiate(itemButton) as GameObject;
                ItemButton button = newButton.GetComponent<ItemButton>();
                button.item = item;
                if (item is Armor) {
                    Armor armor = (Armor)item;
                    button.nameLable.text = armor.slot + " " + item.name.ToString();

                }
                else {
                    button.nameLable.text = item.name.ToString();
                }
                button.durability.text = "Durability: " + item.durability.ToString() + " / " + item.maxDurability.ToString();
                button.icon.sprite = item.sprite;
                newButton.transform.SetParent(contentPanel);
            }
        }

        /// <summary>
        /// This will "Re" Draw the inventroy should be called fairly often incase something happens
        /// </summary>
        public void DrawInventory() {
            // Might not be the most optimized way to do this but it will look instant and its easy
            foreach (Transform inventoryItem in contentPanel.transform) {
                Destroy(inventoryItem.gameObject);
            }

            PopulateInventory();
        }
    }
}

/* example on how the create a item and how to see it
        Item item = InventoryManager.instance.GenerateRandomItem();
        if (item is Weapon)) {
            Weapon item2 = (Weapon)item;
            Debug.Log("Weapon: " + item.name + " " + item2.slot);
        }
        else if (item is Armor) {
            Armor item2 = (Armor)item;
            Debug.Log("Armor: " + item2.slot + " " + item.name);
        }
*/
