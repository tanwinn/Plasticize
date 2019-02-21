using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SeniorIS;
using UnityEditor;

public class ObjectPooler : MonoBehaviour {
    [System.Serializable]
    public class Pool {
        public string tag;
        // number of object
        public int poolSize;
        public float objectSize;
        public bool isInteractive = false;        
        public bool boyanceSimulate = false;
        public DisplayScript displayScript;
        
    }



    public List<Pool> pools;
    Dictionary<string, Queue<GameObject>> poolDictionary;

    public static Metadata.trash KeyByValue(Dictionary<Metadata.trash, string> dict, string val) {
        Metadata.trash key = Metadata.trash.cube;
        foreach (KeyValuePair<Metadata.trash, string> pair in dict) {
            if (pair.Value == val) {
                key = pair.Key;
                break;
            }
        }
        return key;
    }

    // Use this for initialization
    void Start() {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Metadata.trash trashType = KeyByValue(Metadata.trashString, pool.tag);
            // create queue for each pool
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.poolSize; i++) {
                GameObject obj = GameObject.CreatePrimitive(Metadata.trashType[trashType]);
                if (trashType == Metadata.trash.cylinder)
                    pool.displayScript = obj.AddComponent<CylinderDisplay>() as CylinderDisplay;
                else
                    pool.displayScript = obj.AddComponent<CubeDisplay>() as CubeDisplay;

                string assetPath;
                if (pool.isInteractive)
                    assetPath = Metadata.PATH_TO_ASSET_INTERACTIVE;
                else
                    assetPath = Metadata.PATH_TO_ASSET_NONINTERACTIVE;
                pool.displayScript.scriptObject = (Shape)AssetDatabase.LoadAssetAtPath(assetPath + Metadata.trashString[trashType] + pool.objectSize + ".asset", typeof(Shape));
                if (pool.displayScript.scriptObject == null) {
                    CreateScriptableObjects.CreateAsset(trashType, new List<float>() { pool.objectSize }, pool.isInteractive);
                    pool.displayScript.scriptObject = (Shape)AssetDatabase.LoadAssetAtPath(assetPath + Metadata.trashString[trashType] + pool.objectSize + ".asset", typeof(Shape));
                }

                if (pool.boyanceSimulate)
                    obj.AddComponent<ObjectFloat>();

                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public void SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {
        
    }

    // Update is called once per frame
    void Update() {

    }
}
