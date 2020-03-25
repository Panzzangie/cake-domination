using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneHelpers
{
    public enum Scene
    {
        TestScene,
        DoomkyScene,
        // Add Scene name here
    }

    public static string GetSceneName(Scene scene)
    {
        return scene.ToString();
    }
}
