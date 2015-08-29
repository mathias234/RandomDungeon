using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Could use a better name.
/// </summary>
namespace RandomDungeon.Spells {
    public class PlayerSpellAttack : MonoBehaviour {
        public List<Spell> spellBook = new List<Spell>();

        public int selectedSpell = 0; // The index of the selected spell in you spell book

        // Use this for initialization
        void Start() {
            spellBook.Add(SpellGenerator.FireBolt());
            selectedSpell = 0;
        }

        // Update is called once per frame
        void Update() {
            Spell spell = spellBook[this.selectedSpell];
            if (Input.GetMouseButtonDown(1) && PlayerStats.instance.inMenu == false && !spell.OnCoolDown) {
                // Cast the selected spell
                spell.CastSpell();
                spell.OnCoolDown = true;
            }

            foreach (Spell s in spellBook) {
                if (s.OnCoolDown) {
                    if (s.CoolDownTimer >= s.BaseCoolDownTime) {
                        s.OnCoolDown = false;
                        s.LifeTime = 0;
                        s.CoolDownTimer = 0;
                    }
                    else
                        s.CoolDownTimer += Time.deltaTime;
                }
            }
        }
    }
}