namespace RandomDungeon.Items {
    public class Armor : Item {
        public enum ArmorSlots {
            Headguard,
            Chestpiece,
            Legs,
            Hands,
        }

        public ArmorSlots slot;

        public Armor() {
            slot = ArmorSlots.Hands;
        }

        public Armor(string name, int maxDurability, Stats stats, UnityEngine.Sprite sprite, ArmorSlots slot) {
            this.name = name;
            this.maxDurability = maxDurability;
            this.stats = stats;
            this.sprite = sprite;

            this.slot = slot;

            // Durability should always be initialized to the max durability.
            durability = maxDurability;
        }
    }
}
