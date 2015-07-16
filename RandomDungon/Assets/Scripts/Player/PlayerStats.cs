using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour {
    public RectTransform health;
    public RectTransform mana;

    public int maxHealth;
    public int currentHealth;

    public int maxMana;
    public int currentMana;

    private GameObject PlayerInfo;

    public static PlayerStats instance;

    void Awake() {
        instance = this;
        PlayerInfo = GameObject.FindGameObjectWithTag("PlayerInfo");
        health = (RectTransform)PlayerInfo.transform.Find("HealthBar/HealthBar-Filler").GetComponent<RectTransform>();
        mana = PlayerInfo.transform.Find("ManaBar/ManaBar-Filler").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() {
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (currentMana > maxMana)
            currentMana = maxMana;



        float normalizedHealth = ((float)currentHealth - 0) / ((float)maxHealth - 0) * 100;
        health.sizeDelta = new Vector2(normalizedHealth, health.sizeDelta.y);


        float normalizedMana = ((float)currentMana - 0) / ((float)maxMana - 0) * 100;
        mana.sizeDelta = new Vector2(normalizedMana, mana.sizeDelta.y);
    }
}
