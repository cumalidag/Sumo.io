using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        // If the collider is the player
        // then add an impulse force to the enemy
        if (collider.CompareTag("Player"))
        {
            Vector3 direction = gameObject.transform.position - collider.gameObject.transform.position;
            gameObject.GetComponent<Rigidbody>().AddForce(direction * GameManager.instance.tempPlayer.GetComponent<Player>().impulse);         
        }
    }
}
