using UnityEngine;
using System.Collections;
using RandomDungeon.Entity;

namespace RandomDungeon {
    [System.Serializable]
    public class Weapon : MonoBehaviour, IWeapon {
        public float timeSinceLastAttack = 1.7f;
        public float damage;

        public virtual void Update() {

        }

        public virtual void DoAttack(Enemy target) {

        }

        public virtual GameObject myGameObject {
            get {
                return gameObject;
            }
        }
    }
}
