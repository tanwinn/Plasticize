// SourceCode: https://www.youtube.com/watch?v=tdSmKaJvCoA
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour {
    ObjectPooler objectPooler;
    public List<string> Tags;

    private void Start() {
        objectPooler = ObjectPooler.Instance;
    }

    private int frame = 0;
    int waitFrameCount = 10;
    float beforeTime;

    IEnumerator SpawnFromPool() {
        foreach (string tag in Tags) {
            beforeTime = Time.realtimeSinceStartup;
            Debug.Log("Called SpawnFromPool at " + beforeTime);
            objectPooler.SpawnFromPool(tag, transform.position, Quaternion.identity);
            yield return new WaitWhile(() => frame < waitFrameCount);
        }
    }

    private void Update() {
        //float beforeTime = Time.time;
        StartCoroutine(SpawnFromPool());
        Debug.Log("Wait time = " + (Time.realtimeSinceStartup - beforeTime));
        if (frame <= waitFrameCount)
            frame++;
        else {
            frame = 0;
            waitFrameCount = (int)Random.Range(5, 20);
        }
    }
}
