using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
    // initial position of spawned objects
    public Vector3 initialPosition;

    // object to spawn
    public GameObject prefab;

    // interval in seconds between spawns
    public int spawnInterval = 1;

    private float _lastSpawnTime = float.MinValue;

    // Start is called before the first frame update
    void Start()
    {
        _lastSpawnTime = -spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        var time = Time.fixedTime;
        while (time - _lastSpawnTime >= spawnInterval) {
            _lastSpawnTime += spawnInterval;
            Spawn();
        }
    }

    private void Spawn() 
    {
        GameObject product = Instantiate(prefab);
        product.transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
    }
}
