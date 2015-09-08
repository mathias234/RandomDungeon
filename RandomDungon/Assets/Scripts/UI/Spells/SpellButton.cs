using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using RandomDungeon.UI;
using UnityEngine.Events;

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
                SpellManager.instance.selectedSpell = spell;
            }
            else if (eventData.button == PointerEventData.InputButton.Right) {
            }
        }

        public void QustionRemoval() {
            if (SpellManager.instance.spellBook.Count > 1) {
                ModalPanel.Instance().Choice("Are you sure you want to delete this spell", new UnityAction(RemoveSpell), new UnityAction(CancelRemoval));
            }
            else {
                ModalPanel.Instance().Choice("You need atleast one spell in your spellbook");

            }
        }

        public void RemoveSpell() {
            SpellManager.instance.spellBook.Remove(spell);
            SpellManager.instance.DrawSpellBook();
            SpellManager.instance.selectedSpell = SpellManager.instance.spellBook[0];

        }

        public void CancelRemoval() {

        }
    }
}
