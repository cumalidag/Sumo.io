using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayer : MonoBehaviour
{
    public PlayerScriptableObject currentState;
    public int score = 0;
    public int impulse = 0;

    public virtual void Awake()
    {
        score = currentState.score;
        impulse = currentState.impulse;
    }
}
