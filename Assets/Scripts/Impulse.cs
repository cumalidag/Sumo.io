using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("Player"))
        {
            Debug.Log("carpisti");
            Vector3 direction = gameObject.transform.position - collider.gameObject.transform.position;
            gameObject.GetComponent<Rigidbody>().AddForce(direction * GameManager.instance.tempPlayer.GetComponent<Player>().impulse);

        }
    }
}
