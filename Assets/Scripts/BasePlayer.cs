using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is base player class 
public abstract class BasePlayer : MonoBehaviour
{
    public PlayerScriptableObject currentState;
    // base int score
    public int score = 0;
    // base int impulse
    public int impulse = 0;

    // set score and impulse awake
    public virtual void Awake()
    {
        score = currentState.score;
        impulse = currentState.impulse;
    }
}
