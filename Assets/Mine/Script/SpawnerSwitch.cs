using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SeniorIS;

[RequireComponent(typeof(ObjectSpawner))]
[RequireComponent(typeof(ObjectPooler))]
public class SpawnerSwitch : MonoBehaviour {

    public TrashDetector detector;

    [Tooltip("Duration of a spawning")]
    public float spawningSeconds = .5f;

    [Tooltip("Seconds before an explosion after the explosion trigger activates")]
    public float explosionDelaySeconds = 1f;

    ObjectSpawner spawner;
    float spawnerTimer = 0f;

    bool DEBUG_MODE = false;
    ObjectPooler pooler;
    float explosionDelayTimer = 0f;
    bool explosionTrigger = false;

    void Start() {
        spawner = GetComponent<ObjectSpawner>() as ObjectSpawner;
        pooler = GetComponent<ObjectPooler>() as ObjectPooler;
        spawner.enabled = true;
        if (DEBUG_MODE) {
            Debug.Log("Checking spawner and pooler status..");
            Debug.Log("Spawner object: " + spawner.name);
            Debug.Log("Pooler object: " + pooler.name);
        }
    }

    void Update() {
        // Spawning
        if (detector.trashSpawnerTrigger || spawner.enabled) {
            if (spawnerTimer < spawningSeconds) {
                spawner.enabled = true;
                // spawner turns ON
                if (DEBUG_MODE) {
                    Debug.Log("Spawner turns ON");
                    Debug.Log("Spawner isActiveAndEnabled: " + spawner.isActiveAndEnabled);
                }
                spawnerTimer += Time.deltaTime;
            }
            else {
                if (DEBUG_MODE) Debug.Log("Spawner turns OFF");
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
                if (DEBUG_MODE) Debug.Log("Explosion is triggered. " + explosionDelaySeconds + " seconds before the explosion");
                explosionDelayTimer += Time.deltaTime;
            }
            else {
                explosionDelayTimer += Time.deltaTime;
                if (explosionDelayTimer >= explosionDelaySeconds) {
                    if (DEBUG_MODE) Debug.Log("BOOM!");
                    pooler.enabled = true;
                    explosionDelayTimer = 0f;
                }
            }
        }
    }

    public void TriggerExplosion() {
        if (DEBUG_MODE) Debug.Log("Explosion is triggered. " + explosionDelaySeconds + " seconds before the explosion");
        explosionTrigger = true;
    }

}
