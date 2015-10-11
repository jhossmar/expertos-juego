using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider obj){
		if (obj.gameObject.tag== "Player"){

			obj.gameObject.SetActive(false);
		
		}

       Destroy(obj.gameObject);
       Destroy(gameObject);
	}
}
