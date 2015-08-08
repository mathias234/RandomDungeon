using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loot : MonoBehaviour {
    public Item item;

    public void Start() {
        item = InventoryManager.instance.GenerateRandomItem();
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            InventoryManager.instance.AddItem(item);
            Destroy(gameObject);
        }
    }
}
