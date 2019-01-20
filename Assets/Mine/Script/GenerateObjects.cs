using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerateObjects : MonoBehaviour {
    static string PATH_TO_SCRIPT = "Assets/Mine/Script/";
    static string PATH_TO_PREFAB_INTERACTIVE = "Assets/Mine/Prefab-Interactive/";
    static string PATH_TO_CUBE07 = PATH_TO_PREFAB_INTERACTIVE + "cube .07.asset";
    static int CUBE07_COUNT = 10;
    // Use this for initialization
    void Start () {
        List<GameObject> cubes07 = new List<GameObject>();
        for (int i = 0; i < CUBE07_COUNT; i++) {
            cubes07.Add (GameObject.CreatePrimitive(PrimitiveType.Cube));
        }
        foreach (GameObject cube07 in cubes07) {
            CubeDisplay displayScript = cube07.AddComponent<CubeDisplay>() as CubeDisplay;
            displayScript.cube = (Cube)AssetDatabase.LoadAssetAtPath(PATH_TO_CUBE07, typeof(Cube));
            //Debug.Log((Cube)AssetDatabase.LoadAssetAtPath(PATH_TO_CUBE07, typeof(Cube)));
        }
    }     
}
