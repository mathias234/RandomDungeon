using UnityEngine;
using System.Collections;
using RandomDungeon.Entity;

namespace RandomDungeon {
    public class Gun : Weapon {
        public void Awake() {
            timeSinceLastAttack = 1.7f;
            damage = 20f;
        }

        public override void Update() {
            timeSinceLastAttack -= Time.deltaTime;

            // Base Damage
            damage = 15f;

            if (Items.InventoryManager.instance.Upgrade1 != null)
                damage *= (Items.InventoryManager.instance.Upgrade1.DamageMultiplier);
            if (Items.InventoryManager.instance.Upgrade2 != null)
                damage *= (Items.InventoryManager.instance.Upgrade2.DamageMultiplier);

        }

        public override void DoAttack(Enemy target) {
            if (timeSinceLastAttack <= 0) {
                // Start animation
                gameObject.GetComponent<Animator>().SetTrigger("StartRecoil");
                gameObject.GetComponent<AudioSource>().Play();
                if (target != null)
                    target.TakeDamage(damage);
                timeSinceLastAttack = 1.7f;
            }
        }
    }
}
