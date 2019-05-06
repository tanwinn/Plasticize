using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectWhenCollide : MonoBehaviour {

    public float delaySec = 1.5f;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "trash") {
            Destroy(other.gameObject, delaySec);
        }
    }
}
