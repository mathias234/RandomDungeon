using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour {
    public List<GameObject> floorObj;
    public List<GameObject> roofObj;
    public List<GameObject> wallObj;
    public List<GameObject> bossRoomFloorObj;

    public GameObject player;
    public float mapMultiplier = 1;

    public List<GameObject> enemyPrefabs;
    public List<GameObject> bossPrefabs;

    public int mapX = 100;
    public int mapZ = 100;

    public static bool regenerate;

    public static int mapLevel;

    void Start() {
        regenerate = true;
    }

    // Use this for initialization
    void Update() {
        if (regenerate) {
            mapLevel++;
            // Destory all tiles
            foreach (GameObject tileObj in GameObject.FindGameObjectsWithTag("Tile")) {
                DestroyImmediate(tileObj, false);
            }
            // Destory all remaining enemies
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
                DestroyImmediate(enemy, false);
            }


            // Create the map
            TileMap map = new TileMap(mapX, mapZ, 10, 10, 20, 200);

            for (int z = 0; z < mapZ; z++) {
                for (int x = 0; x < mapX; x++) {

                    TileTypes tileType = map.GetTileAt(x, z);

                    if (tileType == TileTypes.Unknown) {
                        // type 0 is where we have nothing incase you want a handler for it like stone or something.
                    }

                    if (tileType == TileTypes.Corridor) {
                        GameObject floor = (GameObject)Instantiate(floorObj[Random.Range(0, floorObj.Count)], new Vector3(x * mapMultiplier, -0.5f * mapMultiplier, z * mapMultiplier), Quaternion.identity);
                        Vector3 locScale = floor.transform.localScale;
                        floor.transform.localScale = new Vector3(locScale.x * mapMultiplier, locScale.y * mapMultiplier, locScale.z * mapMultiplier);
                        floor.transform.parent = this.transform;

                        GameObject roof = (GameObject)Instantiate(roofObj[Random.Range(0, roofObj.Count)], new Vector3(x * mapMultiplier, 0.5f * mapMultiplier, z * mapMultiplier), Quaternion.identity);
                        Vector3 locScale2 = roof.transform.localScale;
                        roof.transform.localScale = new Vector3(locScale2.x * mapMultiplier, locScale2.y * mapMultiplier, locScale2.z * mapMultiplier);
                        roof.transform.parent = this.transform;
                    }
                    if (tileType == TileTypes.Wall) {
                        GameObject wall = (GameObject)Instantiate(wallObj[Random.Range(0, wallObj.Count)], new Vector3(x * mapMultiplier, 0, z * mapMultiplier), Quaternion.identity);
                        Vector3 locScale = wall.transform.localScale;
                        wall.transform.localScale = new Vector3(locScale.x * mapMultiplier, locScale.y * mapMultiplier, locScale.z * mapMultiplier);
                        wall.transform.parent = this.transform;
                    }

                    if (tileType == TileTypes.BossRoom) {
                        GameObject bossRoom = (GameObject)Instantiate(bossRoomFloorObj[Random.Range(0, bossRoomFloorObj.Count)], new Vector3(x * mapMultiplier, -1 * mapMultiplier, z * mapMultiplier), Quaternion.identity);
                        Vector3 locScale = bossRoom.transform.localScale;
                        bossRoom.transform.localScale = new Vector3(locScale.x * mapMultiplier, locScale.y * mapMultiplier, locScale.z * mapMultiplier);
                        bossRoom.transform.parent = this.transform;

                        GameObject roof = (GameObject)Instantiate(roofObj[Random.Range(0, roofObj.Count)], new Vector3(x * mapMultiplier, 1 * mapMultiplier, z * mapMultiplier), Quaternion.identity);
                        Vector3 locScale2 = roof.transform.localScale;
                        roof.transform.localScale = new Vector3(locScale2.x * mapMultiplier, locScale2.y * mapMultiplier, locScale2.z * mapMultiplier);
                        roof.transform.parent = this.transform;
                    }
                }
            }
            int i = 0;
            // Spawn Enemies
            foreach (TileMap.DataRoom room in map.GetAllRooms()) {
                // Figure out the health of the enemies
                if (i == 1) {
                    Enemy.thisLevelHealth = Enemy.thisLevelHealth * (((float)Enemy.healthIncreasePercentage / 100) + 1);
                }

                if (room == map.GetFirstRoom()) {

                }

                else if (!room.isBossRoom) {
                    Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], new Vector3(room.centerX * mapMultiplier, 0 * mapMultiplier, room.centerY * mapMultiplier), Quaternion.identity);
                }
                else
                    Instantiate(bossPrefabs[Random.Range(0, bossPrefabs.Count)], new Vector3(room.centerX * mapMultiplier, 0 * mapMultiplier, room.centerY * mapMultiplier), Quaternion.identity);

                i++;
            }

            TileMap.DataRoom tempRoom = map.GetFirstRoom();
            player.transform.position = new Vector3(tempRoom.centerX * mapMultiplier, 0.5f * mapMultiplier, tempRoom.centerY * mapMultiplier);
            regenerate = false;
        }
    }
}
