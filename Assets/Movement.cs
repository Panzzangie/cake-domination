using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 10f;
    public LayerMask layerMask;
    public AnimationCurve curve;
    public float dashSpeed = 10f;
    public bool isDashing = false;
    public float cdTimer = 3f;

    private float curveSelector = 0f;
    private float cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && cooldown <= 0)
        {
            isDashing = true;
            cooldown = cdTimer;
        }

        if (isDashing)
        {
            curveSelector += Time.deltaTime;
            if (curveSelector > 1)
            {
                isDashing = false;
                curveSelector = 0;
            }
        }

        float dashPower = curve.Evaluate(curveSelector);

        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        velocity.x = speed + dashPower * dashSpeed;
        GetComponent<Rigidbody>().velocity = velocity;

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpHeight));
        }
    }

    private bool IsGrounded()
    {
        Collider collider = GetComponent<CapsuleCollider>();

        Collider [] colliders =  Physics.OverlapCapsule(collider.bounds.center, new
           Vector3(collider.bounds.center.x, collider.bounds.min.y - 0.1f,
           collider.bounds.center.z), 0.18f, layerMask);

        foreach (Collider col in colliders)
        {
            Debug.Log(col.name);
        }

        bool isGrounded = Physics.CheckCapsule(collider.bounds.center, new
            Vector3(collider.bounds.center.x, collider.bounds.min.y - 0.1f,
            collider.bounds.center.z), 0.18f, layerMask);

        return isGrounded;
    }
}
