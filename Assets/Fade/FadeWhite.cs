using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeWhite : MonoBehaviour {

	public Image black;
	public Animator anim;
	public string NextScene;

	void Start(){
		NextScene = StaticNextScene.NextScene;
		Debug.Log (NextScene);
		StartCoroutine (Fading ());
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

		anim.SetBool ("fadehey", true);
		yield return new WaitUntil (() => black.color.a == 0);
		SceneManager.UnloadScene ("FadeWhite");
		}

}
