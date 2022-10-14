using UnityEngine;
using System.Collections;

public class ShroomController : MonoBehaviour, IDamageable
{
    [Header("Shroom")]
    [SerializeField] private Shroom shroomSettings;
    [SerializeField] private GameObject shroomPrefab;

    [Header("newGameCreater")]
    [SerializeField] private NewGameCreator newGameCreator;

    [Header("Parent")]
    [SerializeField] private Transform parent;

    private int randomRangeX;
    private int randomRangeY;

    float newShroomLocationX;
    float newShroomLocationY;

    bool haventSpawnedYet = true;

    private void Start()
    {
        StartCoroutine(GetChanceToSpawnNewShroom());
        newGameCreator.shroomsCounter++;
    }

    public void TakeDamage(int damage)
    {
        HitTarget(damage);
    }

    private IEnumerator GetChanceToSpawnNewShroom()
    {
        while (true)
        {
            int randomNumber = Random.Range(0, 100);
            if (randomNumber == 1 && haventSpawnedYet && newGameCreator.shroomsCounter < 50)
            {
                SpawnNewShroom();
            } else
            {
                haventSpawnedYet = true;
            }
            yield return new WaitForSeconds(3);
        }
    }

    private void HitTarget(int damage)
    {
        int health = shroomSettings.Health;
        health -= damage;
        if (health < 1)
        {
            StopCoroutine(GetChanceToSpawnNewShroom());
        }
    }

    private void SpawnNewShroom()
    {
        randomRangeX = Random.Range(1, 3);
        randomRangeY = Random.Range(1, 3);

        if (!IsNewShroomLocationOutsideTheMap())
        {
            Vector3 newShroomLocation = new Vector3(newShroomLocationX, newShroomLocationY, -1);
            Instantiate(shroomPrefab, newShroomLocation, Quaternion.identity, parent);
            haventSpawnedYet = false;
        }
    }

    private bool IsNewShroomLocationOutsideTheMap()
    {
        float shroomLocationX = gameObject.transform.position.x;
        float shroomLocationY = gameObject.transform.position.y;

        newShroomLocationX = shroomLocationX + randomRangeX;
        newShroomLocationY = shroomLocationY + randomRangeY;

        if (newShroomLocationX < newGameCreator.MapSizeX && newShroomLocationX > 0)
        {
            if (newShroomLocationY < newGameCreator.MapSizeY && newShroomLocationY > 0)
            {
                return false;
            }
        }
        return true;
    }
}
