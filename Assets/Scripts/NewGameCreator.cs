using UnityEngine;

public class NewGameCreator : MonoBehaviour
{
    [SerializeField] private int mapSizeX = 50;
    [SerializeField] private int mapSizeY = 50;
    [SerializeField] private Transform mapTile;
    [SerializeField] private Transform parent;

    [SerializeField] private int teamsAmmount = 3;

    [SerializeField] private Transform cameraLocation;

    private Vector3 mapEdgeLocation = Vector3.zero;

    public int MapSizeX => mapSizeX;
    public int MapSizeY => mapSizeY;

    private void Awake()
    {
        cameraLocation.position = new Vector3(mapSizeX / 2, mapSizeY / 2, -10);

        for (int i = 0; i < mapSizeY; i++)
        {
            SpawnMapTiles(mapEdgeLocation - new Vector3(0, i, 0), mapTile);
            for (int j = 0; j < mapSizeX; j++)
            {
                SpawnMapTiles(mapEdgeLocation + new Vector3(j, i, 0), mapTile);
            }
        }
    }

    private void SpawnMapTiles(Vector3 spawnPosition, Transform tile)
    {
        Instantiate(tile, spawnPosition, Quaternion.identity, parent);
    }
}
