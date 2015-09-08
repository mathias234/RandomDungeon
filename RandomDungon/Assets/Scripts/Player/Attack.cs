using System.Collections.Generic;
using UnityEngine;
using RandomDungeon.Entity;

namespace RandomDungeon {
    public class Attack : MonoBehaviour {
        public List<GameObject> weapons;
        public GameObject selectedWeapon;
        public GameObject weaponSlot;

        private Enemy target;

        private GameObject enemyInfo;

        // Use this for initialization
        void Start() {
            ChangeSelectedWeapon(0);
        }

        // Update is called once per frame
        void Update() {

            if (PlayerStats.instance.inMenu == true)
                return;

            if (selectedWeapon == null) {
                ChangeSelectedWeapon(0);
                return;
            }

            RaycastHit hit;
            if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, 10f))
                target = hit.transform.GetComponent<Enemy>();
            else
                target = null;

            if (Input.GetMouseButtonDown(0)) {
                selectedWeapon.GetComponent<Weapon>().DoAttack(target);
            }
        }

        public void ChangeSelectedWeapon(int id) {
            selectedWeapon = weapons[id];

            foreach (Transform tr in weaponSlot.transform) {
                Destroy(tr);
            }
            GameObject obj = Instantiate(selectedWeapon);
            obj.transform.parent = weaponSlot.transform;
            obj.transform.position = weaponSlot.transform.position;
            selectedWeapon = obj;
        }
    }
}

/*
            if (PlayerStats.instance.inMenu == true)
                return;

            if (weapon == null) {
                weapon = gameObject.GetComponentInChildren<IWeapon>();
                return;
            }

            RaycastHit hit;
            if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, 10f))
                target = hit.transform.GetComponent<Enemy>();
            else
                target = null;

            if (Input.GetMouseButtonDown(0))
                weapon.DoAttack(target);
*/