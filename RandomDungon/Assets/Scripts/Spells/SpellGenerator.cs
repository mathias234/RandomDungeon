using UnityEngine;

public class SpellGenerator : MonoBehaviour{
    public void Start() {
        Bolt firebolt = new Bolt();
        firebolt.Name = "Firebolt";
        firebolt.DamageValue = 20;
        firebolt.Description = "This spell shoots a flaming ball which can take " + firebolt.DamageValue.ToString() + " health";
        firebolt.LineOfSight = true;
        firebolt.BaseCoolDownTime = 5.0f;
        firebolt.Effect = new GameObject();
        firebolt.Range = 20;

        if (firebolt is Bolt) {
            Debug.Log("This is a bolt, with the name " + firebolt.Name + ",  " + firebolt.Description);
            firebolt.CastSpell();
        }
    }
}
