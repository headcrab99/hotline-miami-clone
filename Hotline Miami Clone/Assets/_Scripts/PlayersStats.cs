using UnityEngine;

[CreateAssetMenu(fileName = "PlayersStats")]
public class PlayersStats : ScriptableObject
{
    [Header("Movement")]
    public float speed;
    public Vector2 maxVelocity;
}
