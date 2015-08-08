[System.Serializable]
public class Item {
    public string name;
    public int maxDurability;
    public int durability;

    public Stats stats;

    public UnityEngine.Sprite sprite;


    public Item (){
        this.name = "NoName";
        this.maxDurability = 100;
        this.durability = maxDurability;
    }

    public Item(string name, int maxDurability, Stats stats, UnityEngine.Sprite sprite) {
        this.name = name;
        this.maxDurability = maxDurability;
        this.stats = stats;
        this.sprite = sprite;

        // Durability should always be initialized to the max durability.
        durability = maxDurability;
    }
}
