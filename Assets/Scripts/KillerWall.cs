using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class KillerWall : MonoBehaviour
{
    [SerializeField] private AnimationCurve speedCurve;
    [SerializeField] private float lifetime = 0;

    // Components
    Rigidbody Rb;
    Collider Coll;

    protected void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Coll = GetComponent<Collider>();
    }

    protected void FixedUpdate()
    {
        lifetime += Time.fixedDeltaTime;
        Rb.velocity = new Vector2(speedCurve.Evaluate(lifetime), 0);
    }

    protected void OnTriggerEnter(Collider other)
    {
        Movement movement = other.GetComponent<Movement>();
        if (movement)
        {
            SceneManager.LoadScene(SceneHelpers.GetSceneName(SceneHelpers.Scene.DoomkyScene));
        }
    }
}
