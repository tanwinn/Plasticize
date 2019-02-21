using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class ObjectForce : MonoBehaviour, IPooledObject {
    
    public float upForce = 25f;
    public float sideForce = 7f;

    public void Start() {
        if (GetComponent<Rigidbody>() == null) {
            gameObject.AddComponent<Rigidbody>();
        }
    }
    
    public void OnSpawnedObject() {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        Vector3 force = new Vector3(xForce, yForce, zForce);

        GetComponent<Rigidbody>().velocity = force;
    }
}
