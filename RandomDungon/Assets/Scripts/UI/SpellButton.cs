using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RandomDungeon.Spells {
    public class SpellButton : MonoBehaviour, IPointerClickHandler {
        public Spell spell;
        public Button button;
        public Text nameLable;
        public Image icon;
        public Text mana;
        public Text damage;

        public void OnPointerClick(PointerEventData eventData) {
            if (eventData.button == PointerEventData.InputButton.Left) {
            }
            else if (eventData.button == PointerEventData.InputButton.Right) {
            }
        }
    }
}
