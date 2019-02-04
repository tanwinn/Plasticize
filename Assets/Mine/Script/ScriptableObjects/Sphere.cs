using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sphere", menuName = "Shapes/Sphere")]
public class Sphere : ScriptableObject {
    public float size = .04f;
    public Vector3 position = new Vector3(0, 1f, 0);
    public Material material;
    public bool isInteractive = false;
}
