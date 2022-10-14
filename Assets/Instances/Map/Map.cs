using UnityEngine;

[CreateAssetMenu(fileName = "New Map", menuName = "Map")]
public class Map : ScriptableObject
{
    public int MapSizeX = 50;
    public int MapSizeY = 50;

    public int Teams = 3;
}