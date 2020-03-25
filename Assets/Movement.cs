using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 5f;
    public float jumpForce = 0f;
    public float gravity = 9.81f;
    public float jumpForceReduction = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cakepos = GetComponent<Transform>().position;
        cakepos.x += speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpForce = jumpHeight;
        }

        cakepos.y += jumpForce * Time.deltaTime;
        jumpForce -= jumpForceReduction * Time.deltaTime;

        if (jumpForce < 0)
        {
            jumpForce = 0;
        }
        Debug.Log(jumpForce);

        if (cakepos.y < 1)
        {
            cakepos.y = 1;
        }

        GetComponent<Transform>().position = cakepos;
    }
}
