using UnityEngine;

[CreateAssetMenu(fileName = "New Base", menuName = "Base")]
public class Base : ScriptableObject
{
    public int Attack = 0;
    public int Defence = 1;
    public int Health = 1;
    public Collider2D collider;
    public int SpawnDelay;
}
