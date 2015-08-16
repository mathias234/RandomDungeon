using UnityEngine;

public class SpellGenerator : MonoBehaviour{
    public static Spell FireBolt() {
        Bolt firebolt = new Bolt();
        firebolt.Name = "Firebolt";
        firebolt.DamageValue = 20;
        firebolt.DamageVariance = 10;
        firebolt.Description = "This spell shoots a flaming ball which can take " + firebolt.DamageValue.ToString() + " health";
        firebolt.LineOfSight = true;
        firebolt.BaseLifeTime = 50;
        firebolt.LifeTime = 0;
        firebolt.BaseCoolDownTime = 5;
        firebolt.CoolDownTimer = 0;
        firebolt.Effect = (GameObject)Resources.Load("Prefabs/Spells/Firebolt");
        firebolt.Range = 20;

        return firebolt;
    }
}
