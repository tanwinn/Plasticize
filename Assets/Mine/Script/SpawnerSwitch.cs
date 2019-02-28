using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SeniorIS;

[RequireComponent(typeof(ObjectSpawner))]
[RequireComponent(typeof(ObjectPooler))]
public class SpawnerSwitch : MonoBehaviour {

    public TrashDetector detector;
    //public ObjectSpawner spawner;
    //public ObjectPooler pooler;

    [Tooltip("Duration of a spawning")]
    public float spawningSeconds = 2f;

    [Tooltip("Seconds before an explosion after the explosion trigger activates")]
    public float explosionDelaySeconds = 1f;

    ObjectSpawner spawner;
    float spawnerTimer = 0f;

    bool DEBUG_MODE = true;
    ObjectPooler pooler;
    float explosionDelayTimer = 0f;
    bool explosionTrigger = false;

    void Start() {
        detector.trashSpawnerTrigger = true;
        spawner = GetComponent<ObjectSpawner>() as ObjectSpawner;
        pooler = GetComponent<ObjectPooler>() as ObjectPooler;
        if (DEBUG_MODE) {
            Debug.Log("Checking spawner and pooler status..");
            Debug.Log("Spawner object: " + spawner.name);
            Debug.Log("Pooler object: " + pooler.name);
        }
    }

    void FixedUpdate() {
        // Spawning
        if (detector.trashSpawnerTrigger) {
            if (spawnerTimer < spawningSeconds) {
                // spawner turns ON
                Debug.Log("Spawner turns ON");
                spawner.enabled = true;
                spawnerTimer += Time.deltaTime;
            }
            else {
                Debug.Log("Spawner turns OFF");
                spawner.enabled = false;
                detector.trashSpawnerTrigger = false;
                detector.trashInCounter -= detector.trashMustBeInCounter;
                spawnerTimer = 0f;
            }
        }

        //Explosion
        if (explosionTrigger) {
            if (pooler.enabled) {
                pooler.enabled = false;
                Debug.Log("Explosion is triggered. " + explosionDelaySeconds + " seconds before the explosion");
                explosionDelayTimer += Time.deltaTime;
            }
            else {
                explosionDelayTimer += Time.deltaTime;
                if (explosionDelayTimer >= explosionDelaySeconds) {
                    Debug.Log("BOOM!");
                    pooler.enabled = true;
                    explosionDelayTimer = 0f;
                }
            }
        }
    }

    public void TriggerExplosion() {
        Debug.Log("explosion is triggered. " + explosionDelaySeconds + " seconds before the explosion");
        explosionTrigger = true;
    }

}
