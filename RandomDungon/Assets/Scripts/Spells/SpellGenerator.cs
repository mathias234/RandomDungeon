using UnityEngine;

public class SpellGenerator : MonoBehaviour{
    public static Spell FireBolt() {
        Bolt firebolt = new Bolt();
        firebolt.Name = "Firebolt";
        firebolt.DamageValue = 20;
        firebolt.Description = "This spell shoots a flaming ball which can take " + firebolt.DamageValue.ToString() + " health";
        firebolt.LineOfSight = true;
        firebolt.BaseLifeTime = 2;
        firebolt.LifeTime = firebolt.BaseLifeTime;
        firebolt.BaseCoolDownTime = 5.0f;
        firebolt.Effect = new GameObject();
        firebolt.Range = 20;

        return firebolt;

    }
}
