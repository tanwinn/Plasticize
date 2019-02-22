// SourceCode: https://www.youtube.com/watch?v=tdSmKaJvCoA
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using SeniorIS;

public class ObjectSpawner : MonoBehaviour {
    ObjectPooler objectPooler;
    public List<string> Tags;

    public FloatRange timeBetweenSpawns;
    float currentSpawnDelay;

    public float tiltAngle = -20;

    float timeSinceLastSpawn;
    private void Start() {
        objectPooler = ObjectPooler.Instance;
    }

    void SpawnStuff() {
        foreach (string tag in Tags)
            objectPooler.SpawnFromPool(tag, transform.position, Random.rotation);
    }
    

    private void FixedUpdate() {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= currentSpawnDelay) {
            timeSinceLastSpawn -= currentSpawnDelay;
            currentSpawnDelay = timeBetweenSpawns.RandomInRange;
            //objectPooler.SpawnFromPool(tag, transform.position, Quaternion.identity);
            SpawnStuff();
        }   
    }
}
