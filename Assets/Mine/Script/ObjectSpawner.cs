﻿// SourceCode: https://www.youtube.com/watch?v=tdSmKaJvCoA
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using SeniorIS;

public class ObjectSpawner : MonoBehaviour {
    public ObjectPooler objectPooler;
    public List<string> Tags;

    public FloatRange timeBetweenSpawns;
    float currentSpawnDelay;
    [Tooltip("Delay before initialize the spawner at the beginning")]
    public float beginDelay = 10;

    public float tiltAngle = -20;

    float timeSinceLastSpawn;
    private void Start() {
        //objectPooler = ObjectPooler.Instance;
    }

    void SpawnStuff() {
        foreach (string tag in Tags)
            objectPooler.SpawnFromPool(tag, transform.position, Random.rotation);
    }
    

    private void FixedUpdate() {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= currentSpawnDelay && timeSinceLastSpawn >= beginDelay) {
            timeSinceLastSpawn -= currentSpawnDelay;
            currentSpawnDelay = timeBetweenSpawns.RandomInRange;
            SpawnStuff();
        }   
    }
}
