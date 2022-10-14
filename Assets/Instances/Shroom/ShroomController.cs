using UnityEngine;
using System.Collections;

public class ShroomController : MonoBehaviour
{
    [SerializeField] private Shroom shroom;
    [SerializeField] private GameObject shroomObject;

    [SerializeField] private NewGameCreator newGameCreator;

    [SerializeField] private Transform parent;

    private int randomRangeX;
    private int randomRangeY;

    float newShroomLocationX;
    float newShroomLocationY;

    bool haventSpawnedYet = true;

    private void Start()
    {
        StartCoroutine(GetChanceToSpawnNewShroom());
    }

    IEnumerator GetChanceToSpawnNewShroom()
    {
        while (true)
        {
            int randomNumber = Random.Range(0, 100);
            Debug.Log(randomNumber);
            if (randomNumber == 1 && haventSpawnedYet)
            {
                SpawnNewShroom();
            } else
            {
                haventSpawnedYet = true;
            }
            yield return new WaitForSeconds(1);
        }
    }

    private void SpawnNewShroom()
    {
        randomRangeX = Random.Range(1, 3);
        randomRangeY = Random.Range(1, 3);

        haventSpawnedYet = false;

        if (IsNewShroomLocationOutsideTheMap())
        {
            Vector3 newShroomLocation = new Vector3(newShroomLocationX, newShroomLocationY, -1);
            Instantiate(shroomObject, newShroomLocation, Quaternion.identity, parent);
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
                return true;
            }
        }
        return false;
    }
}
