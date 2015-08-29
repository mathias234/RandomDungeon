using UnityEngine;
using System.Collections;
using RandomDungeon.Entity;

namespace RandomDungeon {
    public class Gun : MonoBehaviour, IWeapon {
        public float timeSinceLastAttack = 1.7f;
        public float damage;

        public void Update() {
            timeSinceLastAttack -= Time.deltaTime;

            // Base Damage
            damage = 15f;

            if (Items.InventoryManager.instance.Upgrade1 != null)
                damage *= (Items.InventoryManager.instance.Upgrade1.DamageMultiplier);
            if (Items.InventoryManager.instance.Upgrade2 != null)
                damage *= (Items.InventoryManager.instance.Upgrade2.DamageMultiplier);

        }

        public void DoAttack(Enemy target) {
            if (timeSinceLastAttack <= 0) {
                // Start animation
                gameObject.GetComponent<Animator>().SetTrigger("StartRecoil");
                gameObject.GetComponent<AudioSource>().Play();
                target.TakeDamage(damage);
                timeSinceLastAttack = 1.7f;
            }
        }

        public GameObject myGameObject {
            get {
                return gameObject;
            }
        }
    }
}
