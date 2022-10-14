using UnityEngine;
using System.Collections;

public class ShroomerController : MonoBehaviour
{
    [SerializeField] private Map mapSettings;
    [SerializeField] private NewGameCreator newGameCreator;

    Vector3 newTargetLocation = Vector3.zero;

    bool doNotHaveDestination = true;
    private void Start()
    {
        StartCoroutine(SetNewDestination());
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, newTargetLocation, 1 * Time.deltaTime);
        if(transform.position == newTargetLocation)
        {
            doNotHaveDestination = true;
        }
    }

    private IEnumerator SetNewDestination()
    {
        while (doNotHaveDestination)
        {
            int newDestinationX = Random.Range(0, mapSettings.MapSizeX);
            int newDestinationY = Random.Range(0, mapSettings.MapSizeY);

            newTargetLocation += new Vector3(newDestinationX, newDestinationY, -1);
            yield return new WaitForSeconds(10);
            doNotHaveDestination = false;
        }
    }
}
