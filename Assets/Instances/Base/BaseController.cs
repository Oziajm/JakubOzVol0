using UnityEngine;
using System.Collections;

public class BaseController : MonoBehaviour, IDamageable
{
    [Header("Public Shrooms")]
    public int shrooms;

    [Header("Base")]
    [SerializeField] private Base baseSettings;
    [SerializeField] private GameObject shroomPrefab;

    [Header("Shroomer")]
    [SerializeField] private Shroomer shroomerSettings;
    [SerializeField] private GameObject shroomerPrefab;

    [Header("Shroomer Parent")]
    [SerializeField] private Transform shroomerParent;

    Vector3 baseLocation;

    int currentBaseHealth;

    bool haventSpawnedShroomerYet = true;

    private void Start()
    {
        baseLocation = gameObject.transform.position;
        StartCoroutine(ShroomerSpawningRoutine());
    }

    private void Update()
    {
        if (shrooms > 5)
        {
            UpgradeBase();
            UpgradeShroomer();

            shrooms = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        currentBaseHealth = baseSettings.Health;
        if(currentBaseHealth < 1)
        {
            Destroy(gameObject);
        }
    }

    private void SpawnNewShroomer()
    {
        int directionX = Random.Range(-1, 1);
        int directionY = Random.Range(-1, 1);

        Vector3 newShroomerLocation = baseLocation + new Vector3(4 * directionX, 4 * directionY,0);

        Instantiate(shroomerPrefab, newShroomerLocation, Quaternion.identity, shroomerParent);
    }

    private IEnumerator ShroomerSpawningRoutine()
    {
        while (true)
        {
            if (haventSpawnedShroomerYet)
            {
                SpawnNewShroomer();
                haventSpawnedShroomerYet = false;
            }
            haventSpawnedShroomerYet = true;
        }
    }

    private void UpgradeBase()
    {
        int baseUpgradeValue = Random.Range(-1, 2);

        baseSettings.Attack += baseUpgradeValue;
        if (baseSettings.Attack < 1)
        {
            baseSettings.Attack = 1;
        }

        baseSettings.Defence += baseUpgradeValue;
        if (baseSettings.Defence < 1)
        {
            baseSettings.Defence = 1;
        }

        baseSettings.Health += baseUpgradeValue;
        if (baseSettings.Health < 1)
        {
            baseSettings.Health = 1;
        }

        baseSettings.SpawnDelay += baseUpgradeValue;
        if (baseSettings.SpawnDelay < 1)
        {
            baseSettings.SpawnDelay = 1;
        }
    }

    private void UpgradeShroomer()
    {
        int shroomerUpgradeValue = Random.Range(-1, 2);

        shroomerSettings.Attack += shroomerUpgradeValue;
        if(shroomerSettings.Attack < 1)
        {
            shroomerSettings.Attack = 1;
        }

        shroomerSettings.Defence += shroomerUpgradeValue;
        if (shroomerSettings.Defence < 1)
        {
            shroomerSettings.Defence = 1;
        }

        shroomerSettings.Health += shroomerUpgradeValue;
        if (shroomerSettings.Health < 1)
        {
            shroomerSettings.Health = 1;
        }

        shroomerSettings.Speed += shroomerUpgradeValue;
        if (shroomerSettings.Speed < 1)
        {
            shroomerSettings.Speed = 1;
        }

        shroomerSettings.ViewRange += shroomerUpgradeValue;
        if (shroomerSettings.ViewRange < 1)
        {
            shroomerSettings.ViewRange = 1;
        }
    }
}
