using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
[RequireComponent(typeof(Rigidbody))]
public class ObjectForce : MonoBehaviour, IPooledObject {
    
    public float upForce = 25f;
    public float sideForce = 7f;

    private Rigidbody rb;
    
    [System.Obsolete]
    public void CheckRigidComponent() {
        rb = gameObject.GetComponent<Rigidbody>();
        //obj = GetComponent<GameObject>();
        if ( rb == null) {
            gameObject.AddComponent<Rigidbody>();
        }
    }
    
    public void OnSpawnedObject() {
        rb = gameObject.GetComponent<Rigidbody>();
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        Vector3 force = new Vector3(xForce, yForce, zForce);

        rb.velocity = force;
    }
}
