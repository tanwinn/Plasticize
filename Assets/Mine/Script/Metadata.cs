using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeniorIS {
    public class Metadata : ScriptableObject {
        public static string PATH_TO_ASSET = "Assets/Mine/";
        public static string PATH_TO_ASSET_INTERACTIVE = PATH_TO_ASSET + "Prefab-Interactive/";
        public static string PATH_TO_ASSET_NONINTERACTIVE = PATH_TO_ASSET + "Prefab-NonInteractive/";
        public static string PATH_TO_BASE_ASSET = PATH_TO_ASSET + "Base/";
        public static float HEIGHT_MAX = 20f;
        public static int INTERACTIVE_COUNT = 20;
        public static int NONINTERACTIVE_COUNT = 100;
        public static List<float> sizeList = new List<float>() { .05f, .11f, .07f, .065f };
        public enum trash {
            cylinder,
            cube,
            sphere
        }
        public static Dictionary<trash, string> trashString = new Dictionary<trash, string>() {
            { trash.cylinder, "Cylinder" },
            { trash.cube, "Cube" },
            { trash.sphere, "Sphere" }
        };

        public static Dictionary<trash, PrimitiveType> trashType = new Dictionary<trash, PrimitiveType>() {
            { trash.cylinder,  PrimitiveType.Cylinder},
            { trash.cube,  PrimitiveType.Cube},
            { trash.sphere,  PrimitiveType.Sphere}
        };
        
    }
}
