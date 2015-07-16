using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour, IWeapon {
    public float timeSinceLastAttack = 1.7f;
    public float damage;

    public void Update() {
        timeSinceLastAttack -= Time.deltaTime;

        // Base Damage
        damage = 15f;

        if (InventoryManager.instance.WeaponUpgradeSlot1 != null)
            damage *= (InventoryManager.instance.WeaponUpgradeSlot1.DamageMultiplier);
        if(InventoryManager.instance.WeaponUpgradeSlot2 != null)
            damage *= (InventoryManager.instance.WeaponUpgradeSlot2.DamageMultiplier);

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
