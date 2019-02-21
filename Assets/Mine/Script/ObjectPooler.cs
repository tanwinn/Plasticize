using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SeniorIS;
using UnityEditor;

public class ObjectPooler : MonoBehaviour {
    #region Pool class
    [System.Serializable]
    public class Pool {
        public string tag;
        // number of object

        [Header("Pool Settings")]
        public int poolSize;
        public float objectSize;

        [Header("Objects in Pool Settings")]
        public bool isInteractive = false;  
        public bool boyanceSimulate = false;
        public bool addForceToObject = true;

        [ConditionalHide("addForceToObject")]
        public float upForce = 25f;
        public float sideForce = 7f;

        [Header("boyanceSimulate")]
        public float waterLevel = .85f;

        [HideInInspector]
        public DisplayScript displayScript;
    }
    #endregion

    #region Singleton
    // The pool is only assigned and referred when Awake
    public static ObjectPooler Instance;

    private void Awake() {
        Instance = this;
    }
    #endregion

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
    
    void Start() {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Metadata.trash trashType = KeyByValue(Metadata.trashString, pool.tag);
            // create queue for each pool
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.poolSize; i++) {
                #region Instantiate game object to put into the pool

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

                if (pool.boyanceSimulate) {
                    ObjectFloat flooaty = obj.AddComponent<ObjectFloat>() as ObjectFloat;
                    flooaty.waterLevel = pool.waterLevel;
                }

                if (pool.addForceToObject) {
                    ObjectForce force = obj.AddComponent<ObjectForce>() as ObjectForce;
                    force.upForce = pool.upForce;
                    force.sideForce = pool.sideForce;
                }

                obj.SetActive(false);
                objectPool.Enqueue(obj);

                #endregion
            }

            // each pool has a unique tag
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {
        if (!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObj != null)
            pooledObj.OnSpawnedObject();
        
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}
