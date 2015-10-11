using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public GameObject disparo;
	public Transform ContenedorDisparo;
	public float fireRate; // velocidad del disparo
	public float nextFire;   // siguienteDisparo
	public GameObject asteroide;
	public float spawnValues;
	public int cantidadAsteroides; // cantidad de asteroides que caeran
    public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public float xMin, xMax, zMin, zMax; // valores maximos y minimos para desplazar a la nave
	private Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		StartCoroutine (crearAsteroide());
	}

	void Update(){
		if(Input.GetButton("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Instantiate(disparo, ContenedorDisparo.position, ContenedorDisparo.rotation);


		}

	}
	// Update is called once per frame 
	//Manejo de la  nave
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

	/**
    *
    *Crea el asteride de manera aleatoria en diferente posicion
    *
	**/
	IEnumerator crearAsteroide(){
		yield return new WaitForSeconds (startWait);
		while (true) {
			for(int i = 0; i<cantidadAsteroides; i++){
				 float auxH = (float)Random.Range(-spawnValues,spawnValues);
				Vector3 spawnPosition = new Vector3(auxH, 7f, 6f);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(asteroide,spawnPosition,spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		
		}



	}


}
