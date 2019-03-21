using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectWhenCollide : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "trash") {
            Destroy(other.gameObject);
        }
    }
}
