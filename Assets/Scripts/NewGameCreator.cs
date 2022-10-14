using UnityEngine;

public class NewGameCreator : MonoBehaviour
{
    [Header("Pubic shroomCounter")]
    public int shroomsCounter = 0;

    [Header("Private Settings")]
    [SerializeField] private int mapSizeX = 50;
    [SerializeField] private int mapSizeY = 50;
    [SerializeField] private int teamsAmmount = 3;

    [Header("MapTile Prefab")]
    [SerializeField] private Transform mapTilePrefab;

    [Header("Map Parent")]
    [SerializeField] private Transform mapParent;

    [Header("Base Prefab")]
    [SerializeField] private Transform basePrefab;

    [Header("Base Parent")]
    [SerializeField] private Transform baseParent;

    [Header("Cam")]
    [SerializeField] private Transform cameraLocation;

    private Vector3 mapCenterLocation = Vector3.zero;

    public int MapSizeX => mapSizeX;
    public int MapSizeY => mapSizeY;

    private void Awake()
    {
        CenterAllObjects();
        GenerateNewMap();
        GenerateNewBases();
    }

    private void GenerateNewMap()
    {
        for (int i = 0; i < mapSizeY; i++)
        {
            SpawnMapTiles(mapCenterLocation - new Vector3(0, i, 0), mapTilePrefab);
            for (int j = 0; j < mapSizeX; j++)
            {
                SpawnMapTiles(mapCenterLocation + new Vector3(j, i, 0), mapTilePrefab);
            }
        }
    }

    private void SpawnMapTiles(Vector3 spawnPosition, Transform tile)
    {
        Instantiate(tile, spawnPosition, Quaternion.identity, mapParent);
    }

    private void CenterAllObjects()
    {
        cameraLocation.position = new Vector3(mapSizeX / 2, mapSizeY / 2, -10);
    }

    private void GenerateNewBases()
    {
        mapCenterLocation += new Vector3(MapSizeX / 2, MapSizeY / 2, 0);

        for(int i = 0; i < teamsAmmount; i++)
        {
            int directionX = Random.Range(-1, 1);
            int directionY = Random.Range(-1, 1);

            int newLocationX = Mathf.RoundToInt(mapSizeX/2 * 0.69f * directionX);
            int newLocationY = Mathf.RoundToInt(mapSizeY/2 * 0.69f * directionY);

            Debug.Log(directionY + " " + directionX);

            Vector3 basePosition = mapCenterLocation + new Vector3(newLocationX, newLocationY,-1);

            Instantiate(basePrefab, basePosition, Quaternion.identity, baseParent);
        }
    }
}
