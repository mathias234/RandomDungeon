using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RandomDungeon.Items {
    public class ItemButton : MonoBehaviour, IPointerClickHandler {
    public Item item;
    public Button button;
    public Text nameLable;
    public Image icon;
    public Text durability;

        public void OnPointerClick(PointerEventData eventData) {
            if (eventData.button == PointerEventData.InputButton.Left) {
                InventoryManager.instance.ShowTooltip(item);
            }
            else if (eventData.button == PointerEventData.InputButton.Right) {
                InventoryManager.instance.EquipItem(item);
            }
        }
    }
}
