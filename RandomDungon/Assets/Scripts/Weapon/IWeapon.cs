using UnityEngine;
using System.Collections;

public interface IWeapon {
	void DoAttack(Enemy target);

	GameObject myGameObject {get;}
}


