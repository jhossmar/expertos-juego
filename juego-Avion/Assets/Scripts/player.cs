using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	public GameObject explocion;
	public Button btnRestart;
	public Text Textnivel;
	public GameObject enemigo;
	private bool visivleEnemigo;

	public GameObject score;
	private int nivel;
	
	
	public float xMin, xMax, zMin, zMax; // valores maximos y minimos para desplazar a la nave
	private Rigidbody rb;


	// Use this for initialization
	void Start () {
		visivleEnemigo = false;
	
		rb = GetComponent<Rigidbody> ();
	
		StartCoroutine (crearAsteroide());
	   
		btnRestart.gameObject.SetActive (false);

		nivel = 1;
		 
		 
	}

	void Update(){
		if(Input.GetButton("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Instantiate(disparo, ContenedorDisparo.position, ContenedorDisparo.rotation);

            GetComponent<AudioSource>().Play();
		}

		if (nivel==6 && visivleEnemigo!=true){

			Vector3 spawnPosition = new Vector3(0f, 7f, 6f);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(enemigo,spawnPosition,spawnRotation);
			visivleEnemigo=true;
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
		 
		while (nivel<=5) {
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
	

    void OnTriggerEnter(Collider otrer){
    if(otrer.gameObject.tag == "asteroide"){
         Instantiate (explocion, transform.position, transform.rotation);
         this.gameObject.SetActive(false);
         btnRestart.gameObject.SetActive (true);
	   }

    }

     public void reloadGame(){

		Application.LoadLevel(Application.loadedLevelName);
	}

	public void  cambiarNivel(int nivel){
		this.nivel = nivel;
		Debug.Log ("nivel del player:"+nivel);
		Textnivel.text = "NIVEL: " + nivel;
	}


}
