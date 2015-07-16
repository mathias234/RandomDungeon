using System.Collections.Generic;
/// <summary>
/// This is a improved version of the old dungeon generator
/// this Class will only handle the Data no graphics will be done here
/// 
/// this class should be able to be easy to convert to any C# environment
/// </summary>
/// 

public enum TileTypes {
    Unknown,
    Corridor,
    Wall,
    BossRoom, /* This shouldnt be used its just for testing */
}
public class TileMap {


    public class DataRoom {
        public int left;
        public int top;
        public int width;
        public int height;

        public bool isConnected = false;

        public bool isBossRoom = false;

        public int right {
            get { return left + width - 1; }
        }

        public int bottom {
            get { return top + height - 1; }
        }

        public int centerX {
            get { return left + width / 2; }
        }

        public int centerY {
            get { return top + height / 2; }
        }

        public bool OverlapsRoom(DataRoom other) {
            if (left > other.right + 2)
                return false;

            if (top > other.bottom + 2)
                return false;

            if (right < other.left - 2)
                return false;

            if (bottom < other.top - 2)
                return false;

            return true;
        }

    }


    int mapSizeX;
    int mapSizeY;

    TileTypes[,] mapData;

    List<DataRoom> rooms;

    public TileMap(int mapSizeX, int mapSizeY, int amountOfRooms, int minRoomSize = 4, int maxRoomSize = 14, int maxRoomCreationFails = 10) {
        DataRoom r;

        this.mapSizeX = mapSizeX;
        this.mapSizeY = mapSizeY;

        mapData = new TileTypes[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++) {
            for (int y = 0; y < mapSizeY; y++) {
                mapData[x, y] = 0;
            }
        }

        rooms = new List<DataRoom>();

        int maxFailes = maxRoomCreationFails;

        while (rooms.Count < amountOfRooms) {


            r = new DataRoom();
            if (rooms.Count == 2) {
                UnityEngine.Debug.Log("we are making a boss room");
                // Do boss room this room should be a little bit bigger
                int rsx = UnityEngine.Random.Range(minRoomSize + 1, maxRoomSize + 2);
                int rsy = UnityEngine.Random.Range(minRoomSize + 1, maxRoomSize + 2);
                r.left = UnityEngine.Random.Range(0, mapSizeX - rsx);
                r.top = UnityEngine.Random.Range(0, mapSizeY - rsy);
                r.width = rsx;
                r.height = rsy;
                r.isBossRoom = true;
            }
            else {
                int rsx = UnityEngine.Random.Range(minRoomSize, maxRoomSize);
                int rsy = UnityEngine.Random.Range(minRoomSize, maxRoomSize);
                r.left = UnityEngine.Random.Range(0, mapSizeX - rsx);
                r.top = UnityEngine.Random.Range(0, mapSizeY - rsy);
                r.width = rsx;
                r.height = rsy;
            }


            if (!RoomOverlaps(r)) {
                rooms.Add(r);
            }
            else {
                maxFailes--;
                if (maxFailes <= 0) {
                    break;
                }
            }
        }

        foreach (DataRoom r2 in rooms) {
            MakeRoom(r2);
        }
        for (int r1 = 0; r1 < rooms.Count; r1++) {
            int j = UnityEngine.Random.Range(1, rooms.Count);

            int r2 = (r1 + j) % rooms.Count;

            if (!rooms[r1].isConnected) {
                MakeCorridors(rooms[r1], rooms[r2]);
            }
        }
        MakeWalls();
    }

    bool RoomOverlaps(DataRoom r) {
        foreach (DataRoom r2 in rooms) {
            if (r.OverlapsRoom(r2)) {
                return true;
            }
        }

        return false;
    }

    void MakeRoom(DataRoom r) {
        for (int x = 0; x < r.width; x++) {
            for (int y = 0; y < r.height; y++) {
                if (x == 0 || x == r.width - 1 || y == 0 || y == r.height - 1) {
                    mapData[r.left + x, r.top + y] = TileTypes.Wall;
                }
                else {
                    if (r.isBossRoom)
                        mapData[r.left + x, r.top + y] = TileTypes.BossRoom;
                    else
                        mapData[r.left + x, r.top + y] = TileTypes.Corridor;
                }
            }
        }
    }

    void MakeCorridors(DataRoom r1, DataRoom r2) {
        int x = r1.centerX;
        int y = r1.centerY;

        while (x != r2.centerX) {
            mapData[x, y] = TileTypes.Corridor;

            x += x < r2.centerX ? 1 : -1;
        }
        while (y != r2.centerY) {
            mapData[x, y] = TileTypes.Corridor;

            y += y < r2.centerY ? 1 : -1;
        }
        r1.isConnected = true;
    }

    void MakeWalls() {
        for (int x = 0; x < mapSizeX; x++) {
            for (int y = 0; y < mapSizeY; y++) {
                if (mapData[x, y] == 0 && HasAdjacentFloor(x, y)) {
                    mapData[x, y] = TileTypes.Wall;
                }
            }
        }
    }
    bool HasAdjacentFloor(int x, int y) {
        if (x > 0 && mapData[x - 1, y] == TileTypes.Corridor)
            return true;
        if (x < mapSizeX - 1 && mapData[x + 1, y] == TileTypes.Corridor)
            return true;
        if (y > 0 && mapData[x, y - 1] == TileTypes.Corridor)
            return true;
        if (y < mapSizeY - 1 && mapData[x, y + 1] == TileTypes.Corridor)
            return true;

        if (x > 0 && y > 0 && mapData[x - 1, y - 1] == TileTypes.Corridor)
            return true;
        if (x < mapSizeX - 1 && y > 0 && mapData[x + 1, y - 1] == TileTypes.Corridor)
            return true;

        if (x > 0 && y < mapSizeY - 1 && mapData[x - 1, y + 1] == TileTypes.Corridor)
            return true;
        if (x < mapSizeX - 1 && y < mapSizeY - 1 && mapData[x + 1, y + 1] == TileTypes.Corridor)
            return true;


        return false;
    }

    public TileTypes GetTileAt(int x, int y) {
        return mapData[x, y];
    }
    public TileTypes[,] GetTileMap() {
        return mapData;
    }

    public List<DataRoom> GetAllRooms() {
        return rooms;
    }

    public DataRoom GetFirstRoom() {
        return rooms[0];
    }
}
