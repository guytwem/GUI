using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnies : MonoBehaviour
{
    [SerializeField] PoolManager spherePool;

    private void Start()
    {
        for (int x = 0; x < 10; x++)
        {
            spherePool.Spawn();
        }
        StartCoroutine(despawnSpheres());
    }

    IEnumerator despawnSpheres()
    {
        while (spherePool.spawnedResource.Count > 0)
        {
            yield return new WaitForSeconds(1f);

            spherePool.Despawn(spherePool.spawnedResource[0]);
        }
    }
}
