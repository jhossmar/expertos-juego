using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public float xMin, xMax, zMin, zMax; // valores maximos y minimos para desplazar a la nave
	private Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {    // Fixed para manejar mejor la fisica
	
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Vector3 vector = new Vector3 (h,5f,v);
		rb.velocity = vector * 10;

		//marcando posisiones maximas del player (Avion )
		rb.position = new Vector3((Mathf.Clamp (rb.position.x, xMin, xMax)),
		                                    6.0f,( Mathf.Clamp(rb.position.z, zMin, zMax)));
		rb.rotation = Quaternion.Euler (0.0f,0.0f,rb.velocity.x * -2); // manejando la Rotacion


		 

	
	}
}
