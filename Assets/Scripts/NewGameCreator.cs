using UnityEngine;

public class NewGameCreator : MonoBehaviour
{
    [SerializeField] private int mapSizeX = 50;
    [SerializeField] private int mapSizeY = 50;
    [SerializeField] private Transform mapTile;
    [SerializeField] private Transform parent;

    [SerializeField] private int teamsAmmount = 3;

    private void Awake()
    {
        for (int i = 0; i < mapSizeY; i++)
        {
            SpawnMapTiles(mapTile.position + new Vector3(0, i, 0), mapTile);
            for (int j = 1; j < mapSizeX; j++)
            {
                SpawnMapTiles(mapTile.position + new Vector3(j, i, 0), mapTile);
            }
        }
    }

    private void SpawnMapTiles(Vector3 spawnPosition, Transform tile)
    {
        Instantiate(tile, spawnPosition, Quaternion.identity, parent);
    }
}
