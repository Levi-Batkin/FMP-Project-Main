using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRenderer : MonoBehaviour {

	void Start () {
		GetComponent<Renderer> ().enabled = false;
	}
	// Disables the default Unity renderer
}
