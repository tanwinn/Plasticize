//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public class GenerateObjects : MonoBehaviour {
//    static string PATH_TO_SCRIPT = "Assets/Mine/Script/";
//    static string PATH_TO_PREFAB_INTERACTIVE = "Assets/Mine/Prefab-Interactive/";
//    static string PATH_TO_CUBE007 = PATH_TO_PREFAB_INTERACTIVE + "cube .07.asset";
//    static int CUBE007_COUNT = 10;
//    static Dictionary<PrimitiveType, KeyValuePair<System.Type, System.Type>> SCRIPT_OBJECT_DICT = new Dictionary<PrimitiveType, KeyValuePair<System.Type, System.Type>>
//    {
//        { PrimitiveType.Cube, new KeyValuePair<System.Type, System.Type>(typeof(Cube), typeof(CubeDisplay)) },
//        { PrimitiveType.Sphere, new KeyValuePair<System.Type, System.Type>(typeof(Sphere), typeof(SphereDisplay)) },
//        { PrimitiveType.Cylinder, new KeyValuePair<System.Type, System.Type>(typeof(Cylinder), typeof(CylinderDisplay)) }
//    };


//    System.Type getObjectType(PrimitiveType primitiType) {
//        return SCRIPT_OBJECT_DICT[primitiType].Key;
//    }

//    System.Type getObjectDisplayScript(PrimitiveType primitiType) {
//        return SCRIPT_OBJECT_DICT[primitiType].Value;
//    }

//    //void GenerateAddPrimitiveDisplay(List<GameObject> objectList, int objectCount, PrimitiveType primiType, string pathToAssetData) {
//    //    for (int i = 0; i < objectCount; i++) {
//    //        objectList.Add(GameObject.CreatePrimitive(primiType));
//    //    }

//    //    foreach (GameObject obj in objectList) {
//    //        CubeDisplay displayScript = obj.AddComponent<CubeDisplay>() as CubeDisplay;
//    //        displayScript = (CubeDisplay)AssetDatabase.LoadAssetAtPath(PATH_TO_CUBE007, typeof(CubeDisplay));
//    //    }
//    //}

//    void GenerateAddPrimitiveDisplay(List<GameObject> objectList, int objectCount, PrimitiveType primiType, string pathToAssetData) {
//        System.Type type = getObjectType(primiType);
//        System.Type tScript = getObjectDisplayScript(primiType);
//        for (int i = 0; i < objectCount; i++) {
//            objectList.Add(GameObject.CreatePrimitive(primiType));
//        }

//        foreach (GameObject obj in objectList) {
//            tScript.GetType() displayScript = obj.AddComponent<tScript.GetType()>() as tScript.GetType();
//            displayScript.obj = (type)AssetDatabase.LoadAssetAtPath(pathToAssetData, typeof(type.GetType()));
//        }
//    }

//    // Use this for initialization
//    void Start() {
//        List<GameObject> cubes007 = new List<GameObject>();
//        List<GameObject> cubes010 = new List<GameObject>();
//        GenerateAddPrimitiveDisplay(cubes007, CUBE007_COUNT, PrimitiveType.Cube, PATH_TO_CUBE007);



//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerateObjects : MonoBehaviour {
    static string PATH_TO_PREFAB_INTERACTIVE = "Assets/Mine/Prefab-Interactive/";
    static string PATH_TO_CUBE07 = PATH_TO_PREFAB_INTERACTIVE + "cube .07.asset";
    static int CUBE07_COUNT = 10;
    // Use this for initialization
    void Start() {
        List<GameObject> cubes07 = new List<GameObject>();
        for (int i = 0; i < CUBE07_COUNT; i++) {
            cubes07.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        }
        foreach (GameObject cube07 in cubes07) {
            CubeDisplay displayScript = cube07.AddComponent<CubeDisplay>() as CubeDisplay;
            displayScript.cube = (Cube)AssetDatabase.LoadAssetAtPath(PATH_TO_CUBE07, typeof(Cube));
            //Debug.Log((Cube)AssetDatabase.LoadAssetAtPath(PATH_TO_CUBE07, typeof(Cube)));
        }
    }
}