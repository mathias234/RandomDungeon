using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RandomDungeon {
    public class MenuManager : MonoBehaviour {
        public List<Items.UIMenuItem> menuItems = new List<Items.UIMenuItem>();
        void Start() {
            for (int x = 0; x < menuItems.Count; x++) {
                if (x == 0) {
                    menuItems[x].menu.SetActive(true);
                    menuItems[x].button.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }
                else {
                    menuItems[x].menu.SetActive(false);
                    menuItems[x].button.GetComponent<UnityEngine.UI.Button>().interactable = true;
                }
            }
        }

        public void SetMenu(int arrayPos) {
            for (int x = 0; x < menuItems.Count; x++) {
                if (x == arrayPos) {
                    menuItems[x].menu.SetActive(true);
                    menuItems[x].button.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }
                else {
                    menuItems[x].menu.SetActive(false);
                    menuItems[x].button.GetComponent<UnityEngine.UI.Button>().interactable = true;
                }
            }
        }
    }
}
