using UnityEngine;
using System;
namespace RandomDungeon.Spells {
    public class Spell : ISpell {
        private string _name;
        private string _description;
        private GameObject _effect;
        private bool _lineOfSight;

        private float _baseLifeTime;
        private float _lifeTime;

        private float _baseCoolDownTime;
        private float _coolDownTimer;
        private bool _onCoolDown;

        private float _mana;

        private Sprite _icon;


        public Spell() {
            Name = "No Name";
            Description = "No Description";
            LineOfSight = true;

            BaseCoolDownTime = 2.0f;
            CoolDownTimer = 0;
            OnCoolDown = false;
        }

        public void CastSpell() {
            LifeTime = 0;
            if (this is Bolt) {
                // Do something
                Bolt bolt = (Bolt)this;
                Debug.Log("Casting Bolt: " + bolt.Name);
                GameObject spell = MonoBehaviour.Instantiate(Effect);
                spell.GetComponent<UpdateBolt>().bolt = bolt;
            }
            else if (this is Buff) {

            }
            else if (this is Spell) {

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

        public float BaseLifeTime {
            get {
                return _baseLifeTime;
            }

            set {
                _baseLifeTime = value;
            }
        }

        public float LifeTime {
            get {
                return _lifeTime;
            }

            set {
                _lifeTime = value;
            }
        }

        public float Mana {
            get {
                return _mana;
            }

            set {
                _mana = value;
            }
        }

        public Sprite Icon {
            get {
                return _icon;
            }

            set {
                _icon = value;
            }
        }
    }
}