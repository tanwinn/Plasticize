using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;


public class CreateScriptableObjects : MonoBehaviour {
    //[MenuItem("Assets/Create/My Scriptable Cube Object")]
    public static void CreateAsset() {
        // Script to create scriptable cubes, sppheres, and cyllinders with random materials
        string PATH_TO_ASSET = "Assets/Mine/";
        string PATH_TO_ASSET_INTERACTIVE = PATH_TO_ASSET + "Prefab-Interactive/";
        
        List<float> cubeSizeList = new List<float>() { .15f, .25f, .2f };

        
        for (int i = 0; i < cubeSizeList.Count; i++) {
            Cube asset = ScriptableObject.CreateInstance<Cube>();
            asset.size = cubeSizeList[i];
            string newAssetName = "Cube " + asset.size;
            asset.isInteractive = true;

            // Randomize Material 
            
            asset.material = RandomizeMaterial.GetRandomMaterial() as Material;
        
            AssetDatabase.CreateAsset(asset, PATH_TO_ASSET_INTERACTIVE + newAssetName + ".asset");
            AssetDatabase.SaveAssets();

            //EditorUtility.FocusProjectWindow();
            //Selection.activeObject = asset;
        }

        for (int i = 0; i < cubeSizeList.Count; i++) {
            Sphere asset = ScriptableObject.CreateInstance<Sphere>();
            asset.size = cubeSizeList[i];
            string newAssetName = "Sphere " + asset.size;
            asset.isInteractive = true;

            // Randomize Material 

            asset.material = RandomizeMaterial.GetRandomMaterial() as Material;

            AssetDatabase.CreateAsset(asset, PATH_TO_ASSET_INTERACTIVE + newAssetName + ".asset");
            AssetDatabase.SaveAssets();

            //EditorUtility.FocusProjectWindow();
            //Selection.activeObject = asset;
        }

        for (int i = 0; i < cubeSizeList.Count; i++) {
            Cylinder asset = ScriptableObject.CreateInstance<Cylinder>();
            asset.width = cubeSizeList[i];
            asset.height = asset.width * 2;
            string newAssetName = "Cylinder " + asset.width;
            asset.isInteractive = true;

            // Randomize Material 

            asset.material = RandomizeMaterial.GetRandomMaterial() as Material;

            AssetDatabase.CreateAsset(asset, PATH_TO_ASSET_INTERACTIVE + newAssetName + ".asset");
            AssetDatabase.SaveAssets();

            //EditorUtility.FocusProjectWindow();
            //Selection.activeObject = asset;
        }
    }

   
}