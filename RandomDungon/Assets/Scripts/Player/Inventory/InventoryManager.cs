using UnityEngine;
using System.Collections.Generic;
public class InventoryManager : MonoBehaviour {
    public List<Item> inventory = new List<Item>();

    public Weapon WeaponUpgradeSlot1;
    public Weapon WeaponUpgradeSlot2;
    public Armor Head;
    public Armor Chest;
    public Armor Legs;
    public Armor Hands;

    public List<string> weaponNames = new List<string>();
    public List<string> armorNames = new List<string>();

    UIManager uiManager;

    public static InventoryManager instance;

    void Awake() {
        instance = this;
        uiManager = GetComponent<UIManager>();

    }

    void Start() {
         for (int x = 0; x < 19; x++) 
           AddItem(GenerateRandomItem());

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
            newItem.stats = new Stats(Random.Range(1, 20 * Map.mapLevel), Random.Range(1, 20 * Map.mapLevel), Random.Range(1, 20 * Map.mapLevel), Random.Range(1, 20 * Map.mapLevel));
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

    // This should be renamed to something like EquipItem(int id)
    // This function is called by the UI when someone tries to equip a item
    // It will figure out  what item is in that UI slot, if we can equip the item, then what type of item(weapon or armor) 
    // then call the appropriate function to equip the item
    public void ItemPressed(int id) {
        UIManager.instance.ClearItemText();
        for (int i = 0; i < inventory.Count; i++) {
            if (inventory[i].inventorySlot == id) {
                if (CanEquipItem(inventory[i]) == false)
                    return;

                if (inventory[i].GetType() == typeof(Weapon)) {
                    Weapon item = (Weapon)inventory[i];
                    EquipWeapon(item);
                }

                else if (inventory[i].GetType() == typeof(Armor)) {
                    Armor item = (Armor)inventory[i];
                    EquipArmor(item);
                }
            }
        }
    }

    // Returns true if we can equip the item if not return false
    public bool CanEquipItem(Item item) {
        return true;
    }

    // Equip a weapon
    public void EquipWeapon(Weapon item) {
        if (WeaponUpgradeSlot1 == null) {
            WeaponUpgradeSlot1 = item;
            uiManager.ChangeWeaponSlot("WeaponSlot1", item.sprite);
            PlayerStats.instance.statModifiers.Add(item.stats);
            RemoveItemFromInventory(item);
        }
        else if (WeaponUpgradeSlot2 == null) {
            WeaponUpgradeSlot2 = item;
            uiManager.ChangeWeaponSlot("WeaponSlot2", item.sprite);
            PlayerStats.instance.statModifiers.Add(item.stats);
            RemoveItemFromInventory(item);
        }

        else if (WeaponUpgradeSlot1 != null && WeaponUpgradeSlot2 != null) {

        }
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
}

    // clear this spot and add it to the inventory
    public void EquipmentClicked(string type) {
        if (type == "Head" && Head != null) {
            AddItem(Head);
            PlayerStats.instance.statModifiers.Remove(Head.stats);
            Head = null;
        }
        else if (type == "Chest" && Chest != null) {
            PlayerStats.instance.statModifiers.Remove(Chest.stats);
            AddItem(Chest);
            Chest = null;
        }
        else if (type == "Legs" && Legs != null) {
            PlayerStats.instance.statModifiers.Remove(Legs.stats);
            AddItem(Legs);
            Legs = null;
        }
        else if (type == "Hands" && Hands != null) {
            PlayerStats.instance.statModifiers.Remove(Hands.stats);
            AddItem(Hands);
            Hands = null;
        }
        else if (type == "WeaponSlot1" && WeaponUpgradeSlot1 != null) {
            PlayerStats.instance.statModifiers.Remove(WeaponUpgradeSlot1.stats);
            AddItem(WeaponUpgradeSlot1);
            WeaponUpgradeSlot1 = null;
        }
        else if (type == "WeaponSlot2" && WeaponUpgradeSlot2 != null) {
            PlayerStats.instance.statModifiers.Remove(WeaponUpgradeSlot2.stats);
            AddItem(WeaponUpgradeSlot2);
            WeaponUpgradeSlot2 = null;
        }
        UIManager.instance.ClearEquipmentSlot(type);

    }

    public void ItemHover(int id) {
        for (int i = 0; i < inventory.Count; i++) {
            if (inventory[i].inventorySlot == id) {
                if (inventory[i].GetType() == typeof(Weapon)) {
                    Weapon item = (Weapon)inventory[i];
                    uiManager.SetItemInfo(
                            "<b><i>" + item.name + "</i></b>      " +
                            item.slot + "\n" +
                            "DamageMultiplier: " + item.DamageMultiplier.ToString() + "\n" +
                            "Stamina: " + item.stats.stamina.ToString() + "\n" +
                            "Strength: " + item.stats.strength.ToString() + "\n" +
                            "Intelligence: " + item.stats.intellect.ToString() + "\n" +
                            "Agility: " + item.stats.agility.ToString()
                        );
                }
                else if (inventory[i].GetType() == typeof(Armor)) {
                    Armor item = (Armor)inventory[i];
                    uiManager.SetItemInfo(
                            "<b><i>" + item.slot + " " + item.name + "</i></b>\n" +
                            "Stamina: " + item.stats.stamina.ToString() + "\n" +
                            "Strength: " + item.stats.strength.ToString() + "\n" +
                            "Intelligence: " + item.stats.intellect.ToString() + "\n" +
                            "Agility: " + item.stats.agility.ToString()
                        );
                }

            }
        }
    }

    public void AddItem(Item item, int invSlot) {
        item.inventorySlot = invSlot;
        inventory.Add(item);
        if (uiManager == null) {
            Debug.Log("Unable to find the ui manager");
            return;
        }
        uiManager.ChangeInventorySlotIcon(invSlot, item.sprite);

    }
    public void AddItem(Item item) {
        int i = 0;

        for (int j = 0; j < UIManager.instance.InventorySlots.Count; j++) {
            UnityEngine.UI.Image invIcon = UIManager.instance.InventorySlots[j].FindChild("Foreground").GetComponent<UnityEngine.UI.Image>();
            if (invIcon.sprite == null) {
                i = j;
                break;
            }
        }
        AddItem(item, i);

    }

    // remove the item from the inventory. BE CARFULL THIS WILL DESTORY THE ITEM
    void RemoveItemFromInventory(Item item) {
        inventory.Remove(item);
        UIManager uiManager = GetComponent<UIManager>();
        if (uiManager == null) {
            Debug.Log("Unable to find the ui manager");
            return;
        }
        uiManager.ChangeInventorySlotIcon(item.inventorySlot, new Sprite());

    }
}

/* example on how the create a item and how to see it
        Item item = InventoryManager.instance.GenerateRandomItem();
        if (item.GetType() == typeof(Weapon)) {
            Weapon item2 = (Weapon)item;
            Debug.Log("Weapon: " + item.name + " " + item2.slot);
        }
        else if (item.GetType() == typeof(Armor)) {
            Armor item2 = (Armor)item;
            Debug.Log("Armor: " + item2.slot + " " + item.name);
        }
*/
