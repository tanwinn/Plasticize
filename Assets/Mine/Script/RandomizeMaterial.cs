using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Return a randomized Material from Asset/Mine/Standard Material

public class RandomizeMaterial : MonoBehaviour {
    
    static List<string> matteMaterialList = new List<string>() { "Orange", "Crimson", "YellowOrange", "Red", "Blue", "Orche", "DarkSeaGreen", "YellowLight", "PinkLight" };
    static List<string> textureMaterialList = new List<string>() { "Waste-Barrel", "Waste-trash", "Dirt", "Waste-trash", "MetalSpinner", "Steve_Spinner", "Steve_Spinner01", "Waste-grafiti", "Waste-trash01" };

    private static Material GetRandomMaterial(List<string> matList) {
        int r = Random.Range(0, matList.Count);
        return Resources.Load<Material>(matList[r]) as Material;
        // EDITOR ONLY
        //return (Material)AssetDatabase.LoadAssetAtPath(Metadata.PATH_TO_ASSET + matList[r] + ".mat", typeof(Material)) as Material;
    }

    public static Material GetMatteMaterial() {
        return GetRandomMaterial(matteMaterialList);
    }

    public static Material GetTextureMaterial() {
        return GetRandomMaterial(textureMaterialList);
    }

}
