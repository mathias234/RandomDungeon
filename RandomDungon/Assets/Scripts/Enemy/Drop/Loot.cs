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

            int i = 0;

            for (int j = 0; j < UIManager.instance.InventorySlots.Count; j++) {
                Image invIcon = UIManager.instance.InventorySlots[j].FindChild("Foreground").GetComponent<Image>();
                if (invIcon.sprite == null) {
                    i = j;
                    break;
                }
            }

            InventoryManager.instance.AddItem(item, i);
            Destroy(gameObject);
        }
    }
}
