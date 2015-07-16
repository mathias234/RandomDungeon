using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetupInventoryItem : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        string slotNumber = Regex.Match(gameObject.name, @"\d+").Value;
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry onEnter = new EventTrigger.Entry();
        onEnter.eventID = EventTriggerType.PointerEnter;
        onEnter.callback.AddListener((eventData) => { InventoryManager.instance.ItemHover(int.Parse(slotNumber)); });
        trigger.triggers.Add(onEnter);

        EventTrigger.Entry onLeave = new EventTrigger.Entry();
        onLeave.eventID = EventTriggerType.PointerExit;
        onLeave.callback.AddListener((eventData) => { UIManager.instance.ClearItemText(); });
        trigger.triggers.Add(onLeave);

    }

    // Update is called once per frame
    void Update () {
	
	}
}
