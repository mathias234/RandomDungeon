using UnityEngine;
using System.Collections;

public class HideMouse : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
