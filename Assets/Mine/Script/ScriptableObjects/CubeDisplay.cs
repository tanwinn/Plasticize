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
        transform.localPosition = cube.position;
        if (cube.isInteractive)
            gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
    }

    public void setPosition(Vector3 inputVector) {
        transform.localPosition = inputVector;
    }

    public void setIsInteractive(bool input) {
        if (input)
            gameObject.AddComponent<Leap.Unity.Interaction.InteractionBehaviour>();
        else if (gameObject.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>())
            Destroy(gameObject.GetComponent<Leap.Unity.Interaction.InteractionBehaviour>());
    }
}
