using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sphere", menuName = "Shapes/Sphere")]
public class Sphere : ScriptableObject {
    public float size = .04f;
    public Material material;
    public bool isInteractive = false;
    public float mass = .5f;
}
