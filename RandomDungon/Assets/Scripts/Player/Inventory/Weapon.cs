public class Weapon : Item {
    public enum WeaponUpgrade {
        Damage
    }

    public WeaponUpgrade slot;

    public float DamageMultiplier;

    public Weapon() {
        this.slot = WeaponUpgrade.Damage;
        this.DamageMultiplier = 0;

    }

    public Weapon(string name, int maxDurability, Stats stats, UnityEngine.Sprite sprite, WeaponUpgrade slot, float DamageMultiplier) {
        this.name = name;
        this.maxDurability = maxDurability;
        this.stats = stats;
        this.sprite = sprite;

        this.slot = slot;

        this.DamageMultiplier = DamageMultiplier;

        // Durability should always be initialized to the max durability.
        durability = maxDurability;
    }

}
