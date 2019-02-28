// SourceCode: https://www.youtube.com/watch?v=tdSmKaJvCoA
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
        
        public bool addForceToObject = true;
        [ConditionalHide("addForceToObject")] public float upForce = 25f;
        [ConditionalHide("addForceToObject")] public float sideForce = 7f;

        [Header("Random float range 0.5 to 2")]
        public FloatRange randomFloater;

        [Header("Velocity")]
        public float velocity;
        public FloatRange angularVelocity;
        public FloatRange randomVelocity;

        public bool boyanceSimulate = false;
        [ConditionalHide("boyanceSimulate")] public float waterLevel = .85f;
        [ConditionalHide("boyanceSimulate")] public float floatThreshold = 2f;
        [ConditionalHide("boyanceSimulate")] public float waterDensity = .8f;
        [ConditionalHide("boyanceSimulate")] public float downForce = .5f;

        [HideInInspector]
        public DisplayScript displayScript;
    }
    #endregion

    #region Singleton
    // The pool is only assigned and referred when Awake
    //public static ObjectPooler Instance;

    private void Start() {
        CreatePools();
        //Instance = this;
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
    
    private void CreatePools() {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Metadata.trash trashType = KeyByValue(Metadata.trashString, pool.tag);
            // create queue for each pool
            Queue<GameObject> objectPool = new Queue<GameObject>();
            ScriptableAssetManager.CreateAsset(trashType, new List<float>() { pool.objectSize }, pool.isInteractive, false);
            Shape sObj = ScriptableAssetManager.LoadAsset(trashType, pool.objectSize, pool.isInteractive);

            for (int i = 0; i < pool.poolSize; i++) {
                GameObject obj = GameObject.CreatePrimitive(Metadata.trashType[trashType]);
                obj.name = "From" + pool.tag + pool.objectSize + "Pool";
                #region Instantiate game object to put into the pool
                
                DisplayScript displayScript;
                if (trashType == Metadata.trash.cylinder)
                    displayScript = obj.AddComponent<CylinderDisplay>() as CylinderDisplay;
                else
                    displayScript = obj.AddComponent<CubeDisplay>() as CubeDisplay;
                displayScript.scriptObject = sObj;

                obj.transform.localScale *= pool.randomFloater.RandomInRange;

                // Add Floating script if boyanceSimulate is true
                if (pool.boyanceSimulate) {
                    ObjectFloat flooaty = obj.AddComponent<ObjectFloat>() as ObjectFloat;
                    flooaty.waterLevel = pool.waterLevel;
                    flooaty.floatThreshold = pool.floatThreshold;
                    flooaty.waterDensity = pool.waterDensity;
                    flooaty.downForce = pool.downForce;
                }

                // Add Force script if addForceToObject is true
                if (pool.addForceToObject) {
                    ObjectForce force = obj.AddComponent<ObjectForce>() as ObjectForce;
                    force.upForce = pool.upForce;
                    force.sideForce = pool.sideForce;
                    force.randomVelocity = pool.randomVelocity;
                    force.angularVelocity = pool.angularVelocity;
                }

                #endregion

                obj.SetActive(false);
                objectPool.Enqueue(obj);
                
            }

            // each pool has a unique tag
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    private void OnDisable() {
        poolDictionary.Clear();
    }

    private void OnEnable() {
        CreatePools();
    }
    

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {
        if (!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObj != null)
            pooledObj.OnSpawnedObject();
        
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}
