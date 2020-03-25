using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision stay");
        Block block = collision.gameObject.GetComponent<Block>();
        if (block)
            GameObject.Destroy(block.gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision enter");
        Block block = collision.gameObject.GetComponent<Block>();
        if (block)
            GameObject.Destroy(block.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter");
        Block block = other.gameObject.GetComponent<Block>();
        if (block)
            GameObject.Destroy(block.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger stay");
        Block block = other.gameObject.GetComponent<Block>();
        if (block)
            GameObject.Destroy(block.gameObject);
    }
}
