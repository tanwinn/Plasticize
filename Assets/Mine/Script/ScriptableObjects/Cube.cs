using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cube", menuName = "Shapes/Cube")]
public class Cube : ScriptableObject {
    public float size = .1f;
    public Material material;
    public bool isInteractive = false;
}
