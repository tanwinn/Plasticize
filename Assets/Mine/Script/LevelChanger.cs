using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    public TrashDetector detector;
    int levelToLoad;

    // Use this for initialization
    void Start () {
        animator.ResetTrigger("FadeOutTrigger");
    }
	
	// Update is called once per frame
	void Update () {
        if (detector.sceneChangeTrigger)
            FadeToLevel(1);
    }

    public void FadeToLevel(int levelIndex) {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOutTrigger");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
    }
}
