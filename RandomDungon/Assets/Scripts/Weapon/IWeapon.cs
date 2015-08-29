using UnityEngine;
using System.Collections;
using RandomDungeon.Entity;
namespace RandomDungeon {
    public interface IWeapon {
        void DoAttack(Enemy target);

        GameObject myGameObject { get; }
    }
}

