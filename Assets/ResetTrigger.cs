using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour
{
    public Transform player;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        player.position = startPosition;
    }
}
