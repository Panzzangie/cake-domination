using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillerBlock : Block
{
    protected void OnTriggerEnter(Collider other)
    {
        Movement movement = other.GetComponent<Movement>();
        if (movement)
        {
            SceneManager.LoadScene(SceneHelpers.GetSceneName(SceneHelpers.Scene.DoomkyScene));
        }
    }
}
