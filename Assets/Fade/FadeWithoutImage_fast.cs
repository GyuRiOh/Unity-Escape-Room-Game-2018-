using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeWithoutImage_fast : MonoBehaviour {

	public Image black;
	public Animator anim;
	public string NextScene;

	void Start(){
		NextScene = StaticNextScene.NextScene;
		StartCoroutine (Fading ());
		Application.targetFrameRate = 60;
	}

	IEnumerator Fading() {
		yield return new WaitUntil (() => black.color.a == 1);
		SceneManager.LoadScene (NextScene, LoadSceneMode.Additive);

		if (AdditionalLoad.additional == "both") {
			SceneManager.LoadScene ("SwitchWallUI", LoadSceneMode.Additive);
			SceneManager.LoadScene ("Inventory", LoadSceneMode.Additive);
		} else if (AdditionalLoad.additional == "onlyINVEN") {
			SceneManager.LoadScene ("Inventory", LoadSceneMode.Additive);
		}

		anim.SetBool ("fadeout", true);
		yield return new WaitUntil (() => black.color.a == 0);
		SceneManager.UnloadScene ("FadeWithoutImage_fast");
		}

}
