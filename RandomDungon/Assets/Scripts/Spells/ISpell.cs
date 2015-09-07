using UnityEngine;
namespace RandomDungeon.Spells {
    public interface ISpell {
        string Name { get; set; }
        string Description { get; set; }
        GameObject Effect { get; set; }
        bool LineOfSight { get; set; }

        float BaseLifeTime { get; set; }
        float LifeTime { get; set; }

        float BaseCoolDownTime { get; set; }
        float CoolDownTimer { get; set; }
        bool OnCoolDown { get; set; }

        float Mana { get; set; }
        Sprite Icon { get; set; }


        void CastSpell();
    }
}