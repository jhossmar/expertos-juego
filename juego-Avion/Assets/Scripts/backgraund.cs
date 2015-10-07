using UnityEngine;
using System.Collections;

public class backgraund : MonoBehaviour {

	public float velocidad =0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0f, (Time.time*velocidad)); // hace que la textura se mueva en el eje y
	}
}
