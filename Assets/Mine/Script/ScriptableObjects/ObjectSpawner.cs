// SourceCode: https://www.youtube.com/watch?v=tdSmKaJvCoA
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    ObjectPooler objectPooler;
    public List<string> Tags;

    private void Start() {
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate() {
        foreach (string tag in Tags) {
            objectPooler.SpawnFromPool(tag, transform.position, Quaternion.identity);
        }
    }
}
