using System;

namespace RandomDungeon.Spells {
    [Serializable]
    public class Buff : Spell, IBuff {
        private int _buffValue;
        private float _baseBuffDuration;
        private float _buffDuration;

        public Buff() {
            _buffValue = 0;
            _baseBuffDuration = 0.0f;
            _baseBuffDuration = 0.0f;
        }

        public int BuffValue {
            get {
                return _buffValue;
            }

            set {
                _buffValue = value;
            }
        }

        public float BaseBuffDuration {
            get {
                return _baseBuffDuration;
            }

            set {
                _baseBuffDuration = value;
            }
        }

        public float BuffDuration {
            get {
                return _buffDuration;
            }

            set {
                _buffDuration = value;
            }
        }
    }
}