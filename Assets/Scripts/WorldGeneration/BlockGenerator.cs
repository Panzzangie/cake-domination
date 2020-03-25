using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField] protected float lastPositionX;
    [SerializeField] protected float blocksWidth = 1;
    [SerializeField] protected float perlinNoiseScale = 1;
    [SerializeField] protected List<GameObject> blocksPrefabs = new List<GameObject>();

    private void Start()
    {
        lastPositionX = transform.position.x;
    }

    private void FixedUpdate()
    {
        while (lastPositionX + blocksWidth <= transform.position.x)
        {

            GameObject blockPrefab = blocksPrefabs[UnityEngine.Random.Range(0, blocksPrefabs.Count)];
            float noise = Mathf.PerlinNoise(perlinNoiseScale * lastPositionX, 0);
            if (noise < 0.2f)
            {
                // nothing its a cliff
            }
            else
            {
                float height = Mathf.RoundToInt(noise * 10);
                for (int i = 0; i < height; i++)
                    GameObject.Instantiate(blockPrefab, new Vector3(lastPositionX, -0.5f + i, 0), Quaternion.identity);
            }
            lastPositionX += blocksWidth;
        }
    }
}
