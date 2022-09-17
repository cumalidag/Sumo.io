using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Camera will be chase this object which is the player
    [SerializeField] private Transform _target;
    // Camera will be chase this object from _offSet position
    [SerializeField] private Vector3 _offSet = new Vector3(0, 10, -5);
    // Camera chase speed
    [SerializeField] private float _chaseSpeed = 5;
    void Start()
    {
        // Set the camera position to the player position
        if (!_target)
        {
            _target = GameManager.instance.player.transform;
        }
    }
    private void LateUpdate()
    {
        // Camera chase the player within a distance
        transform.position = Vector3.Lerp(transform.position, _target.position + _offSet, _chaseSpeed * Time.deltaTime);
    }
}
