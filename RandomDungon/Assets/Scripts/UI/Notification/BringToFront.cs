using UnityEngine;

namespace RandomDungeon.UI {
    public class BringToFront : MonoBehaviour {
        void OnEnable() {
            transform.SetAsLastSibling();
        }
    }
}