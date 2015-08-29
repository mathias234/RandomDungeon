using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RandomDungeon.Items {
    public class ItemButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
        public Item item;
        public Button button;
        public Text nameLable;
        public Image icon;
        public Text durability;

        public void OnPointerClick(PointerEventData eventData) {
            if (eventData.button == PointerEventData.InputButton.Left) {
                InventoryManager.instance.EquipItem(item);
            }
        }

        public void OnPointerEnter(PointerEventData eventData) {
            InventoryManager.instance.ShowTooltip(item);
        }

        public void OnPointerExit(PointerEventData eventData) {
            InventoryManager.instance.ShowTooltip(EquipmentType.None);
        }
    }
}
