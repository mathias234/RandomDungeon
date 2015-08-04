using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Could use a better name.
/// </summary>
public class PlayerSpellAttack : MonoBehaviour {
    public List<Spell> spellBook = new List<Spell>();

    public int selectedSpell = 0; // The index of the selected spell in you spell book

	// Use this for initialization
	void Start () {
        spellBook.Add(SpellGenerator.FireBolt());
        selectedSpell = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(2)) {
            // Cast the selected spell
            spellBook[selectedSpell].CastSpell();
            StartCoroutine(spellBook[selectedSpell].UpdateSpell());
        }
	}
}
