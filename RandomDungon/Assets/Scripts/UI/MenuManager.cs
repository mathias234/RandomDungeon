using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour {
    public List<GameObject> menuItems = new List<GameObject>();
	void Start () {
        for (int x = 0; x < menuItems.Count; x++) {
            if (x == 0) {
                menuItems[x].SetActive(true);
            }
            else {
                menuItems[x].SetActive(false);
            }
        }
	}

    public void SetMenu(int arrayPos) {
        for (int x = 0; x < menuItems.Count; x++) {
            if (x == arrayPos) {
                menuItems[x].SetActive(true);
            }
            else {
                menuItems[x].SetActive(false);
            }
        }
    }
}
