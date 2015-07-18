using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour {
    private Stats _baseStats = new Stats(20, 20, 20, 20);

    public Stats BaseStats {
        get { return _baseStats; }
    }

    [SerializeField]
    public List<Stats> statModifiers = new List<Stats>();

    public RectTransform health;
    public RectTransform mana;

    public int baseMaxHealth;
    private int maxHealth;
    public int currentHealth;

    public int baseMaxMana;
    [SerializeField] private int maxMana;
    public int currentMana;

    private GameObject PlayerInfo;

    public static PlayerStats instance;

    void Awake() {
        instance = this;
        PlayerInfo = GameObject.FindGameObjectWithTag("PlayerInfo");
        health = (RectTransform)PlayerInfo.transform.Find("HealthBar/HealthBar-Filler").GetComponent<RectTransform>();
        mana = PlayerInfo.transform.Find("ManaBar/ManaBar-Filler").GetComponent<RectTransform>();
    }
    void Start() {
        maxHealth = baseMaxHealth + GetStats().stamina;
        maxMana = baseMaxMana + GetStats().intellect;
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update() {
        maxHealth = baseMaxHealth + GetStats().stamina;
        maxMana = baseMaxMana + GetStats().intellect;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (currentMana > maxMana)
            currentMana = maxMana;

        float normalizedHealth = ((float)currentHealth - 0) / ((float)maxHealth - 0) * 100;
        health.sizeDelta = new Vector2(normalizedHealth, health.sizeDelta.y);


        float normalizedMana = ((float)currentMana - 0) / ((float)maxMana - 0) * 100;
        mana.sizeDelta = new Vector2(normalizedMana, mana.sizeDelta.y);
    }

    public Stats GetStats() {
        // Why i have to do this is still a mystery
        Stats newStats = new Stats(BaseStats.stamina, BaseStats.strength, BaseStats.agility, BaseStats.intellect);

        // calculate the new stats based to the base stats and the stat modifiers
        for(int x = 0; x < statModifiers.Count; x++) {
            newStats.stamina += statModifiers[x].stamina;
            newStats.strength += statModifiers[x].strength;
            newStats.intellect += statModifiers[x].intellect;
            newStats.agility += statModifiers[x].agility;
        }
        return newStats;
    }
}
