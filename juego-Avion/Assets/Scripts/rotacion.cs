using UnityEngine;
using System.Collections;

public class rotacion : MonoBehaviour {
   
     public float rotation;
     
     private Rigidbody rb;

	// Use this for initialization
	void Start () {
	   rb = GetComponent<Rigidbody>();
       rb.angularVelocity = Random.insideUnitSphere * rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
