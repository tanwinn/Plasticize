using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;


public class CreateScriptableObjects : MonoBehaviour {
    // Script to create scriptable cubes, sppheres, and cyllinders with random materials
    static string PATH_TO_ASSET = "Assets/Mine/";
    static string PATH_TO_ASSET_INTERACTIVE = PATH_TO_ASSET + "Prefab-Interactive/";
    static string PATH_TO_ASSET_NONINTERACTIVE = PATH_TO_ASSET + "Prefab-NonInteractive/";


    static void createSphereAsset(List<float> sizeList, bool isInteractive) {
        for (int i = 0; i < sizeList.Count; i++) {
            Sphere asset = ScriptableObject.CreateInstance<Sphere>();
            asset.size = sizeList[i];
            string newAssetName = "Sphere " + asset.size;
            asset.isInteractive = isInteractive;
            // Randomize Material 
            asset.material = RandomizeMaterial.GetRandomMaterial() as Material;

            // Save Asset
            string savePath = PATH_TO_ASSET_INTERACTIVE;
            if (!isInteractive)
                savePath = PATH_TO_ASSET_NONINTERACTIVE;
            AssetDatabase.CreateAsset(asset, savePath + newAssetName + ".asset");
            AssetDatabase.SaveAssets();
        }
    }

    static void createCubeAsset(List<float> sizeList, bool isInteractive) {
        for (int i = 0; i < sizeList.Count; i++) {
            Cube asset = ScriptableObject.CreateInstance<Cube>();
            asset.size = sizeList[i];
            string newAssetName = "Cube " + asset.size;
            asset.isInteractive = isInteractive;

            // Randomize Material 

            asset.material = RandomizeMaterial.GetRandomMaterial() as Material;

            // Save Asset
            string savePath = PATH_TO_ASSET_INTERACTIVE;
            if (!isInteractive)
                savePath = PATH_TO_ASSET_NONINTERACTIVE;
            AssetDatabase.CreateAsset(asset, savePath + newAssetName + ".asset");
            AssetDatabase.SaveAssets();

        }
    }

    static void createCylinderAsset(List<float> sizeList, bool isInteractive) {
        for (int i = 0; i < sizeList.Count; i++) {
            Cylinder asset = ScriptableObject.CreateInstance<Cylinder>();
            asset.width = sizeList[i];
            asset.height = asset.width * 2;
            string newAssetName = "Cylinder " + asset.width;
            asset.isInteractive = isInteractive;
            // Randomize Material 
            asset.material = RandomizeMaterial.GetRandomMaterial() as Material;

            // Save Asset
            string savePath = PATH_TO_ASSET_INTERACTIVE;
            if (!isInteractive)
                savePath = PATH_TO_ASSET_NONINTERACTIVE;
            AssetDatabase.CreateAsset(asset, savePath + newAssetName + ".asset");
            AssetDatabase.SaveAssets();

        }
    }
    public static void CreateAsset(List<float> sizeList, bool isInteractive = true) {
        if (sizeList.Count == 0) Debug.Log("ERROR:: CreateScriptableObjects.CreateAsset: missing sizeList!");
        createCubeAsset(sizeList, isInteractive);
        createCylinderAsset(sizeList, isInteractive);
        createSphereAsset(sizeList, isInteractive);
    }

   
}