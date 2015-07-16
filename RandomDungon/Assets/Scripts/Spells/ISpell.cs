using UnityEngine;
using System.Collections;

public interface ISpell {
    string Name { get; set; }
    GameObject Effect { get; set; }
    bool LineOfSight { get; set; }

    float BaseCoolDownTime { get; set; }
    float CoolDownTimer { get; set; }
    float OnCoolDown { get; set; }

    void CastSpell();
    void UpdateSpell();
}
