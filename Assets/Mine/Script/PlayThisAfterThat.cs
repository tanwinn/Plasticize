using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayThisAfterThat : MonoBehaviour {
    // After That Audio finished playing, play This audio
    public AudioSource thatSource;
    public float afterSeconds = 10f;
    private AudioSource thisSource;
    public bool thisSourceLoop = true;

    private bool thatFinished = false;
    float timer = 0f;

	// Use this for initialization
	void Start () {
        thisSource = gameObject.GetComponent<AudioSource>();
        Debug.Log(thisSource.clip);
        thisSource.enabled = false;
        thisSource.loop = thisSourceLoop;
        thatSource.loop = false;
        thatSource.enabled = true;
        thisSource.playOnAwake = true;
	}
	

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
		if (timer >= afterSeconds) {
            if (!thatFinished) {
                thatFinished = true;
                thisSource.enabled = true;
            }
            timer -= afterSeconds;
            thatSource.volume -= .1f;
        }
	}
}
