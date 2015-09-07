namespace RandomDungeon.Spells {
    public interface IBolt : ISpell {
        float DamageValue { get; set; }
        float DamageVariance { get; set; }
        float Range { get; set; }
        float Mana { get; set; }
    }
}