using UnityEngine;
using UnityEngine.EventSystems;

public enum EquipmentType {
    None,
    Head,
    Chest,
    Legs,
    Hands,
    Upgrade1,
    Upgrade2
}

namespace RandomDungeon.Items {
    public class EquipmentButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
        public EquipmentType type;

        public void OnPointerClick(PointerEventData eventData) {
            if (eventData.button == PointerEventData.InputButton.Left) {
                InventoryManager.instance.EquipmentClicked(type);
            }
        }

        public void OnPointerEnter(PointerEventData eventData) {
            InventoryManager.instance.ShowTooltip(type);
        }

        public void OnPointerExit(PointerEventData eventData) {
            InventoryManager.instance.ShowTooltip(EquipmentType.None);
        }
    }
}
