using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyAI))]
public class BasicEnemy : Enemy {
	private float timeToAttack = 0;

    public void Start() {
        Debug.Log(Map.mapLevel);

        MaxHealth = thisLevelHealth;
        Health = MaxHealth;

		Mana = 100;
		MaxMana = 100;
	}

	public override void Attack() {
		if(Vector3.Distance(transform.position, player.transform.position) > ai._minDistance)
			return;

		// This enemy is a very basic enemy it just has a simple attack when close enough to player no spells just normal melee
		timeToAttack -= Time.deltaTime;
		if(timeToAttack <= 0) {
            player.currentHealth -= 10;
			timeToAttack = 2f;
		}
	}
}
