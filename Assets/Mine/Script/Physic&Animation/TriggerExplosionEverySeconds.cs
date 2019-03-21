using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnerSwitch))]
public class TriggerExplosionEverySeconds : MonoBehaviour {

    SpawnerSwitch spawnerSwitch;

    public FloatRange SecondsRange;
	
    float timer;
    float _range;

    private void Start() {
        spawnerSwitch = GetComponent<SpawnerSwitch>();
        _range = SecondsRange.RandomInRange;
        timer = 0f;
    }

    // Update is called once per frame
    void Update () {
		if (timer < _range) {
            timer += Time.deltaTime;
        }
        else {
            _range = SecondsRange.RandomInRange;
            timer -= _range;
            spawnerSwitch.TriggerExplosion();
        }
	}
}
