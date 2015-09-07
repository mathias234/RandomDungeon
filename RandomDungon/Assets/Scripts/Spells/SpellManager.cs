using UnityEngine;
using System.Collections.Generic;

namespace RandomDungeon.Spells {
    public class SpellManager : MonoBehaviour {
        public List<Spell> spellBook = new List<Spell>();
        public Spell selectedSpell; 

        public GameObject spellButton;
        public Transform contentPanel;

        public static SpellManager instance;

        bool hasUpdated;

        public void Awake() {
            instance = this;
        }
        public void Update() {
            if (!hasUpdated) {
                DrawSpellBook();
                hasUpdated = true;
            }
        }

        void PopulateInventory() {
            foreach (var spell in spellBook) {
                GameObject newButton = Instantiate(spellButton) as GameObject;
                SpellButton button = newButton.GetComponent<SpellButton>();
                button.spell = spell;
                if (spell is Bolt) {
                    Bolt bolt = (Bolt)spell;
                    button.nameLable.text = bolt.Name.ToString();

                    button.mana.text = "Mana: " + bolt.Mana.ToString();
                    button.damage.text = "Damage: " + (bolt.DamageValue - bolt.DamageVariance).ToString() + " / " + (bolt.DamageValue + bolt.DamageVariance).ToString();
                    button.icon.sprite = bolt.Icon;
                }
                newButton.transform.SetParent(contentPanel);
            }
        }

        /// <summary>
        /// This will "Re" Draw the Spell Book
        /// </summary>
        public void DrawSpellBook() {
            // Might not be the most optimized way to do this but it will look instant and its easy
            foreach (Transform spellBookItem in contentPanel.transform) {
                Destroy(spellBookItem.gameObject);
            }

            PopulateInventory();
        }
    }
}