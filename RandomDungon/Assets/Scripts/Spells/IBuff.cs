using UnityEngine;
using System.Collections;

public interface IBuff : ISpell {
    int BuffValue { get; set; }
    float BaseBuffDuration { get; set; }
    float BuffDuration { get; set; }
}

