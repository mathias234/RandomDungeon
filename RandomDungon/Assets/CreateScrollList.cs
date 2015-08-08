using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class CreateScrollList : MonoBehaviour {

    public List<Item> itemList;

    public GameObject itemButton;
    public Transform contentPanel;

	// Use this for initialization
	void Start () {
        PopulateList();
	}

    void PopulateList() {
 
    }
}
