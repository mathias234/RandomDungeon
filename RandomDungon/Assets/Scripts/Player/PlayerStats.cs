using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
namespace RandomDungeon {
    public class PlayerStats : MonoBehaviour {
        private Stats _baseStats = new Stats(20, 20, 20, 20);

        public Stats BaseStats {
            get { return _baseStats; }
        }

        [SerializeField]
        public List<Stats> statModifiers = new List<Stats>();

        public RectTransform health;
        public RectTransform mana;

        public float baseMaxHealth;
        [SerializeField]
        private float maxHealth;
        public float currentHealth;

        public float baseMaxMana;
        [SerializeField]
        private float maxMana;
        public float currentMana;

        private GameObject PlayerInfo;

        public bool inCombat = false;
        public bool inMenu = false;

        public float regenAmount = 1.0f;       // The amount of health/mana you gain every secound

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
            if (currentHealth < maxHealth) {
                //Regen health
                currentHealth += regenAmount * Time.deltaTime;
            }

            if (currentMana < maxMana) {
                //Regen mana
                currentMana += regenAmount * Time.deltaTime;
            }

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
            for (int x = 0; x < statModifiers.Count; x++) {
                newStats.stamina += statModifiers[x].stamina;
                newStats.strength += statModifiers[x].strength;
                newStats.intellect += statModifiers[x].intellect;
                newStats.agility += statModifiers[x].agility;
            }
            return newStats;
        }
    }
}