using UnityEngine;


public class Attack : MonoBehaviour {
	private IWeapon weapon;

	private Enemy target;

	private GameObject enemyInfo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(weapon == null) {
			weapon = gameObject.GetComponentInChildren<IWeapon>();
			return;
		}

		if(enemyInfo == null) {
			enemyInfo = GameObject.FindGameObjectWithTag("EnemyInfo");
			return;
		}

		RaycastHit hit;
		if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, 10f))
			target = hit.transform.GetComponent<Enemy>();
		else 
			target = null;


		if(target == null) {
			enemyInfo.SetActive(false);
			return;
		} else {
			enemyInfo.SetActive(true);
		}


		// Adjust the health and mana bar of the enemy
		RectTransform healthBar = (RectTransform)enemyInfo.transform.Find("HealthBar/HealthBar-Filler").GetComponent<RectTransform>();
		RectTransform manaBar = enemyInfo.transform.Find("ManaBar/ManaBar-Filler").GetComponent<RectTransform>();

		float normalizedHealth = ((float)target.Health - 0) / ((float)target.MaxHealth - 0) * 100;
		healthBar.sizeDelta = new Vector2(normalizedHealth, healthBar.sizeDelta.y);
		
		
		float normalizedMana = ((float)target.Mana - 0) / ((float)target.MaxMana - 0) * 100;
		manaBar.sizeDelta = new Vector2(normalizedMana, manaBar.sizeDelta.y);


		if(Input.GetMouseButtonDown(0))
			weapon.DoAttack(target);
	}
}
