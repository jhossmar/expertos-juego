using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class enemigo : MonoBehaviour {
	//public GameObject disparo;
    private  int DisparosASoportar;
	private int disparoRecividos;
	public Text mensageNivel;
	public  GameObject explocion;
	// Use this for initialization
	void Start () {
		DisparosASoportar = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (disparoRecividos==DisparosASoportar){
			GUILayout.Label ("GANASTE!!!");
		}
	}



	void OnTriggerEnter(Collider otrer){
		if(otrer.gameObject.tag == "bolt"){
			Instantiate(explocion, otrer.gameObject.transform.position, otrer.gameObject.transform.rotation);
			disparoRecividos++;

		}
		
	}
}
