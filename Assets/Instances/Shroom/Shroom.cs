using UnityEngine;

[CreateAssetMenu(fileName = "New Shroom", menuName = "Shroom")]
public class Shroom : ScriptableObject
{
    public int Attack = 0;
    public int Defence = 1;
    public int Health = 1;
    public Collider2D collider;
}
