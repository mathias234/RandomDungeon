namespace RandomDungeon {
    [System.Serializable]
    public class Stats {
        public int stamina;
        public int strength;
        public int intellect;
        public int agility;

        public Stats() {
            this.stamina = 0;
            this.strength = 0;
            this.intellect = 0;
            this.agility = 0;
        }

        public Stats(int stamina, int strength, int intellect, int agility) {
            this.stamina = stamina;
            this.strength = strength;
            this.intellect = intellect;
            this.agility = agility;
        }
    }
}