using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using RandomDungeon.UI;
using UnityEngine.Events;

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


        public void QustionRemoval() {
            ModalPanel.Instance().Choice("Are you sure you want to delete this item", new UnityAction(RemoveItem),  new UnityAction(CancelRemoval));

        }

        public void RemoveItem() {
            InventoryManager.instance.inventory.Remove(item);
            InventoryManager.instance.DrawInventory();
        }

        public void CancelRemoval() {

        }

        public void OnPointerEnter(PointerEventData eventData) {
            InventoryManager.instance.ShowTooltip(item);
        }

        public void OnPointerExit(PointerEventData eventData) {
            InventoryManager.instance.ShowTooltip(EquipmentType.None);
        }
    }
}
