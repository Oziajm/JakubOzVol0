using UnityEngine;

[CreateAssetMenu(fileName = "New Shroomer", menuName = "Shroomer")]
public class Shroomer : ScriptableObject
{
    public int Attack = 0;
    public int Defence = 1;
    public int Health = 1;
    public Collider2D collider;
    public int Speed = 3;
    public int ViewRange = 2;
}
