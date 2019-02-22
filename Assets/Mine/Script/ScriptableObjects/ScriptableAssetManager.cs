﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using SeniorIS;

// Scriptable Object/asset manager used to generate scriptable asset from scriptabe object templates, input sizeList, shape, and Interactivity
// E.g.: Shape: sphere, sizeList, and Interactable = true --> Sphere+Size

public class ScriptableAssetManager : MonoBehaviour {
    // Script to create scriptable cubes, sppheres, and cyllinders with random materials
    public static void CreateAsset(Metadata.trash shape, List<float> sizeList, bool isInteractive, bool overrideExistedAssets) {
        foreach (float size in sizeList) {
            if (!overrideExistedAssets)
                // Make sure the asset doesn't exist
                if (ATrashAssetExists(shape, size, isInteractive))
                    break;
            Shape asset = ScriptableObject.CreateInstance<Shape>();
            asset.size = size;
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

    public static void CreateAllAssets(List<float> sizeList, bool isInteractive = true, bool overrideExistedAssets = true) {
        if (sizeList.Count == 0) Debug.LogError("CreateScriptableObjects.CreateAsset: missing sizeList!");
        CreateAsset(Metadata.trash.cube, sizeList, isInteractive, overrideExistedAssets);
        CreateAsset(Metadata.trash.cylinder, sizeList, isInteractive, overrideExistedAssets);
        CreateAsset(Metadata.trash.sphere, sizeList, isInteractive, overrideExistedAssets);
    }

    private static string getPath(bool isInteractive) {
        if (isInteractive)
            return Metadata.PATH_TO_ASSET_INTERACTIVE;
        else
            return Metadata.PATH_TO_ASSET_NONINTERACTIVE;
    }

    public static Shape LoadAsset(Metadata.trash shape, float size, bool isInteractive) {
        return (Shape)AssetDatabase.LoadAssetAtPath(getPath(isInteractive) + Metadata.trashString[shape] + size + ".asset", typeof(Shape)) as Shape;
    }

    public static bool ATrashAssetExists(Metadata.trash shape, float size, bool isInteractive) {
        string assetPath = Metadata.PATH_TO_ASSET_NONINTERACTIVE;
        if (isInteractive)
            assetPath = Metadata.PATH_TO_ASSET_INTERACTIVE;

        Shape asset = (Shape)AssetDatabase.LoadAssetAtPath(assetPath + Metadata.trashString[shape] + size + ".asset", typeof(Shape));

        return (asset != null);
    }

    public static bool AllTrashAssetExist(Metadata.trash shape, List<float> sizeList, bool isInteractive) {
        foreach (float size in sizeList) {
            if (!ATrashAssetExists(shape, size, isInteractive))
                return false;
        }
        return true;
    }
}