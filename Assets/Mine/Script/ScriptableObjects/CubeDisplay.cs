using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDisplay : MonoBehaviour {
    public Cube cube;
    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material = cube.material;
        name = cube.name;
        transform.localScale = new Vector3(cube.size, cube.size, cube.size);
        transform.localPosition = new Vector3(1f, 1f, 1f);
        if (cube.isInteractive)
            gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
    }
}
