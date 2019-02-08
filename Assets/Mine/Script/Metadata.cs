using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeniorIS {
    public class Metadata : ScriptableObject {
        public static string PATH_TO_ASSET = "Assets/Mine/";
        public static string PATH_TO_ASSET_INTERACTIVE = PATH_TO_ASSET + "Prefab-Interactive/";
        public static string PATH_TO_ASSET_NONINTERACTIVE = PATH_TO_ASSET + "Prefab-NonInteractive/";
        public static float HEIGHT_MAX = 20f;
        public static int INTERACTIVE_COUNT = 20;
        public static int NONINTERACTIVE_COUNT = 280;
        public static List<float> sizeList = new List<float>() { .05f, .11f, .07f, .065f };

    }
}
