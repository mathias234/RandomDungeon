using System;

[Serializable]
public class Bolt : Spell, IBolt {
    float _damageValue;
    float _damageVariance;
    float _range;

    public float DamageValue {
        get {
            return _damageValue;
        }

        set {
            _damageValue = value;
        }
    }

    public float DamageVariance {
        get {
            return _damageVariance;
        }

        set {
            _damageVariance = value;
        }
    }

    public float Range {
        get {
            return _range;
        }

        set {
            _range = value;
        }
    }
}
