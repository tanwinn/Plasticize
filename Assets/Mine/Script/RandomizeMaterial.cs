using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Return a randomized Material from Asset/Mine/Standard Material

public class RandomizeMaterial : MonoBehaviour {

    static string PATH_TO_ASSET = "Assets/Mine/";
    static string PATH_TO_MATERIAL = PATH_TO_ASSET + "MaterialStandard/";

    public static Material GetRandomMaterial() {
        List<string> matList = new List<string>() { "Orange", "Crimson", "YellowOrange", "Red", "Blue", "Orche", "Orange02", "YellowLight", "PinkLight" };
        int r = Random.Range(0, matList.Count);
        //Debug.Log("RandomizeMaterial Material Object = " + (Material)AssetDatabase.LoadAssetAtPath(PATH_TO_MATERIAL + matList[r] + ".mat", typeof(Material)));
        return (Material)AssetDatabase.LoadAssetAtPath(PATH_TO_MATERIAL + matList[r] + ".mat", typeof(Material)) as Material;

    }
}
