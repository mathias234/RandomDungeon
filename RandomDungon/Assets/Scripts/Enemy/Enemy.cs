using UnityEngine;
using System.Collections;
namespace RandomDungeon.Entity {
    public class Enemy : MonoBehaviour {
        // Base Stats - Every enemy has them.
        public float Health;
        public float MaxHealth;
        public float Mana;
        public float MaxMana;

        // Every enemy should be aware of its own AI and the player
        public PlayerStats player;
        public EnemyAI ai;

        public GameObject lootItem;

        public static int healthIncreasePercentage = 20; // How much the health will be increased  with each level
        public static float thisLevelHealth = 100;

        void Update() {
            if (player == null) {
                GameObject temp = GameObject.FindGameObjectWithTag("Player");
                if (temp != null) {
                    player = temp.GetComponent<PlayerStats>();
                }
                return;
            }

            if (ai == null) {
                ai = gameObject.GetComponent<EnemyAI>();
                return;
            }



            HandleDeath();
            Attack();
        }
        /// This function needs to be overwritten as there is no "Default" attack sequence
        public virtual void Attack() {
        }

        public virtual void TakeDamage(float amount) {
            Health -= amount;
        }
        /// the default death seqence is just to be removed but this can be overwritten for more advance death
        public virtual void HandleDeath() {

            if (Health <= 0) {
                Instantiate(lootItem, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}