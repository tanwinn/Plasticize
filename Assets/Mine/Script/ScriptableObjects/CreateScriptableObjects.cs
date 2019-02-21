using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using SeniorIS;

public class CreateScriptableObjects : MonoBehaviour {
    // Script to create scriptable cubes, sppheres, and cyllinders with random materials
    public static void CreateAsset(Metadata.trash shape, List<float> sizeList, bool isInteractive) {
        for (int i = 0; i < sizeList.Count; i++) {
            Shape asset = ScriptableObject.CreateInstance<Shape>();
            asset.size = sizeList[i];
            string newAssetName = Metadata.trashString[shape] + asset.size;
            asset.isInteractive = isInteractive;
            // Randomize Material 
            asset.material = RandomizeMaterial.GetRandomMaterial() as Material;

            // Save Asset
            string savePath = Metadata.PATH_TO_ASSET_INTERACTIVE;
            if (!isInteractive)
                savePath = Metadata.PATH_TO_ASSET_NONINTERACTIVE;
            AssetDatabase.CreateAsset(asset, savePath + newAssetName + ".asset");
            AssetDatabase.SaveAssets();

        }
    }

    public static void CreateAllAssets(List<float> sizeList, bool isInteractive = true) {
        if (sizeList.Count == 0) Debug.LogError("CreateScriptableObjects.CreateAsset: missing sizeList!");
        CreateAsset(Metadata.trash.cube, sizeList, isInteractive);
        CreateAsset(Metadata.trash.cylinder, sizeList, isInteractive);
        CreateAsset(Metadata.trash.sphere, sizeList, isInteractive);
    }

   
}