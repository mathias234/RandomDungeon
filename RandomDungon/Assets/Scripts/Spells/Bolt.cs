using System;
namespace RandomDungeon.Spells {
    [Serializable]
    public class Bolt : Spell, IBolt {
        private float _damageValue;
        private float _damageVariance;
        private float _range;

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
}