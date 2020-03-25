using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 10f;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        velocity.x = speed;
        GetComponent<Rigidbody>().velocity = velocity;

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpHeight));
        }
    }

    private bool IsGrounded()
    {
        Collider collider = GetComponent<CapsuleCollider>();

        bool isGrounded = Physics.CheckCapsule(collider.bounds.center, new
            Vector3(collider.bounds.center.x, collider.bounds.min.y - 0.1f,
            collider.bounds.center.z), 0.18f, layerMask);

        return isGrounded;
    }
}
