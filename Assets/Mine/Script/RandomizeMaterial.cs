using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Return a randomized Material from Asset/Mine/Standard Material

public class RandomizeMaterial : MonoBehaviour {

    static string PATH_TO_ASSET = "Assets/Mine/";
    static string PATH_TO_MATERIAL = PATH_TO_ASSET + "MaterialStandard/";
    static List<string> matteMaterialList = new List<string>() { "Orange", "Crimson", "YellowOrange", "Red", "Blue", "Orche", "DarkSeaGreen", "YellowLight", "PinkLight" };
    static List<string> textureMaterialList = new List<string>() { "Waste-Barrel", "Waste-trash", "Dirt", "Waste-trash", "MetalSpinner", "Steve_Spinner", "Steve_Spinner01", "Waste-grafiti", "Waste-trash01" };

    private static Material GetRandomMaterial(List<string> matList) {
        int r = Random.Range(0, matList.Count);
        return (Material)AssetDatabase.LoadAssetAtPath(PATH_TO_MATERIAL + matList[r] + ".mat", typeof(Material)) as Material;
    }

    public static Material GetMatteMaterial() {
        return GetRandomMaterial(matteMaterialList);
    }

    public static Material GetTextureMaterial() {
        return GetRandomMaterial(textureMaterialList);
    }

}
