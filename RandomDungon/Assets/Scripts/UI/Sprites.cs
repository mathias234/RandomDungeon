using UnityEngine;
using System.Collections.Generic;
namespace RandomDungeon {
    public class Sprites : MonoBehaviour {
        public List<Sprite> weaponSprites = new List<Sprite>();
        public List<Sprite> headSprites = new List<Sprite>();
        public List<Sprite> chestSprites = new List<Sprite>();
        public List<Sprite> legsSprites = new List<Sprite>();
        public List<Sprite> handsSprites = new List<Sprite>();

        public static Sprites i;

        public void Start() {
            i = this;
        }
    }
}
