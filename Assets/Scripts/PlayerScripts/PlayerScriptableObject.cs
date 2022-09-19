using UnityEngine;

// This is PlayerScriptableObject class
[CreateAssetMenu(fileName = "PlayerStates", menuName = "Player", order = 1)]

public class PlayerScriptableObject : ScriptableObject
{
    public int score = 0;
    public int impulse = 0;

}
