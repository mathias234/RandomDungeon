using UnityEngine;
using System.Collections;

public class CaveMonster : Enemy {
    private float timeToAttack = 0;
    public Animator animator;

    public void Start() {
        animator = GetComponent<Animator>();

        MaxHealth = thisLevelHealth * 1.5f;
        Health = MaxHealth;

        Mana = 100;
        MaxMana = 100;
    }

    public override void Attack() {
        if (Vector3.Distance(transform.position, player.transform.position) > ai._minDistance)
            return;

        // This enemy is a very basic enemy it just has a simple attack when close enough to player no spells just normal melee
        timeToAttack -= Time.deltaTime;
        if (timeToAttack <= 0) {
            // Select a random attack animation because this enemy has three
            int attAnim = Random.Range(0, 2);
            animator.SetTrigger("Attack" + attAnim.ToString());
            player.currentHealth -= 10;
            timeToAttack = 2f;
        }
    }

    public override void TakeDamage(float amount) {
        animator.SetTrigger("Hit");
        Health -= amount;
    }

    public override void HandleDeath() {
        if (Health <= 0) {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsDead", true);
            gameObject.GetComponent<EnemyAI>().enabled = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Enemy>().enabled = false;
            Map.regenerate = true;
        }
    }
}
