namespace RandomDungeon.Spells {
    public interface IBuff : ISpell {
        int BuffValue { get; set; }
        float BaseBuffDuration { get; set; }
        float BuffDuration { get; set; }
    }
}

