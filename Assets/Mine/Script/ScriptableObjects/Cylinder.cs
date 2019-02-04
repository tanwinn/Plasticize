using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cylinder", menuName = "Shapes/Cylinder")]
public class Cylinder : ScriptableObject {
    public float width = .04f;
    public float height = .07f;
    public Vector3 position = new Vector3(0, 2f, 0);
    public Material material;
    public bool isInteractive = false;
}
