﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

	void Start () {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play (0);
	}
		
}
