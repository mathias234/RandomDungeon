using UnityEngine;
using RandomDungeon.Entity;
namespace RandomDungeon {
    public interface IWeapon {
        void DoAttack(Enemy target);

        GameObject myGameObject { get; }
    }
}

