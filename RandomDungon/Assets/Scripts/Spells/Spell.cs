using UnityEngine;
using System.Collections;
using System;

public class Spell : ISpell {
    private string _name;
    private string _description;
    private GameObject _effect;
    private bool _lineOfSight;

    private float _baseCoolDownTime;
    private float _coolDownTimer;
    private bool _onCoolDown;

    public Spell() {
        Name = "No Name";
        Description = "No Description";
        Effect = new GameObject();
        LineOfSight = true;

        BaseCoolDownTime = 2.0f;
        CoolDownTimer = 0;
        OnCoolDown = false;
    }

    public void CastSpell() {
        if (this is Bolt) {
            // Do something
            Bolt bolt = (Bolt)this;
        }
        else if (this is Buff) {
            // Do Something
            Buff buff = (Buff)this;
        }
        else if (this is Spell) {
            // it shouldnt come to this.
        }
    }

    /// <summary>
    /// Used to keep track of the spell after its been cast counting down spell cooldowns and such
    /// </summary>
    public IEnumerator UpdateSpell() {
        while (true) {
            if (this is Bolt) {
                // Do something
                Bolt bolt = (Bolt)this;

            }
            else if (this is Buff) {
                // Do Something
                Buff buff = (Buff)this;
            }
            else if (this is Spell) {
                // it shouldnt come to this.
            }
            yield return new WaitForSeconds(0);
        }
    }

    public string Name {
        get {
            return _name;
        }

        set {
            _name = value;
        }
    }

    public string Description {
        get {
            return _description;
        }

        set {
            _description = value;
        }
    }

    public GameObject Effect {
        get {
            return _effect;
        }

        set {
            _effect = value;
        }
    }

    public bool LineOfSight {
        get {
            return _lineOfSight;
        }

        set {
            _lineOfSight = value;
        }
    }

    public float BaseCoolDownTime {
        get {
            return _baseCoolDownTime;
        }

        set {
            _baseCoolDownTime = value;
        }
    }

    public float CoolDownTimer {
        get {
            return _coolDownTimer;
        }

        set {
            _coolDownTimer = value;
        }
    }

    public bool OnCoolDown {
        get {
            return _onCoolDown;
        }

        set {
            _onCoolDown = value;
        }
    }
}
