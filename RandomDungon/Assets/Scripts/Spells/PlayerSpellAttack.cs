using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Could use a better name.
/// </summary>
namespace RandomDungeon.Spells {
    public class PlayerSpellAttack : MonoBehaviour {
        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            Spell spell = SpellManager.instance.selectedSpell;
            if (Input.GetMouseButtonDown(1) && PlayerStats.instance.inMenu == false && !spell.OnCoolDown) {
                // Cast the selected spell
                spell.CastSpell();
                spell.OnCoolDown = true;
            }

            foreach (Spell s in SpellManager.instance.spellBook) {
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