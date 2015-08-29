using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum EquipmentType {
    Head,
    Chest,
    Legs,
    Hands,
    Upgrade1,
    Upgrade2
}

namespace RandomDungeon.Items {
    public class EquipmentButton : MonoBehaviour, IPointerClickHandler {
        public EquipmentType type;

        public void OnPointerClick(PointerEventData eventData) {
            if (eventData.button == PointerEventData.InputButton.Left) {
                InventoryManager.instance.ShowTooltip(type);
            }
            else if (eventData.button == PointerEventData.InputButton.Right) {
                InventoryManager.instance.EquipmentClicked(type);
            }
        }
    }
}
