using UnityEngine;

namespace RandomDungeon.Spells {

    /// <summary>
    /// Someday i may make a generator for making random spells but atm i will have defined spells
    /// </summary>
    public class SpellGenerator {
        public static Spell Firebolt() {
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
            firebolt.Effect = Resources.Load<GameObject>("Prefabs/Spells/Firebolt");
            firebolt.Icon = Resources.Load<Sprite>("SpellSprites/fireball");
            firebolt.Range = 20;
            firebolt.Mana = Random.Range(firebolt.DamageValue, firebolt.DamageValue + 5);

            return firebolt;
        }

        public static Spell Frostbolt() {
            Bolt frostbolt = new Bolt();
            frostbolt.Name = "Frostbolt";
            frostbolt.DamageValue = 20;
            frostbolt.DamageVariance = 10;
            frostbolt.Description = "This spell shoots a frozen ball which can take " + frostbolt.DamageValue.ToString() + " health";
            frostbolt.LineOfSight = true;
            frostbolt.BaseLifeTime = 50;
            frostbolt.LifeTime = 0;
            frostbolt.BaseCoolDownTime = 5;
            frostbolt.CoolDownTimer = 0;
            frostbolt.Effect = Resources.Load<GameObject>("Prefabs/Spells/Frostbolt");
            frostbolt.Icon = Resources.Load<Sprite>("SpellSprites/frostball");
            frostbolt.Range = 20;
            frostbolt.Mana = Random.Range(frostbolt.DamageValue, frostbolt.DamageValue + 5);

            return frostbolt;
        }
    }
}