using UnityEngine;
using System.Collections;

public interface ISpell {
    string Name { get; set; }
    string Description { get; set; }
    GameObject Effect { get; set; }
    bool LineOfSight { get; set; }

    float BaseCoolDownTime { get; set; }
    float CoolDownTimer { get; set; }
    bool OnCoolDown { get; set; }

    void CastSpell();
    void UpdateSpell();
}
