using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {
    public GameObject explocion;
	public GameObject puntuacion;
  

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider otrer){
		
	   if(otrer.gameObject.tag == "hit"){
      
	     Destroy(gameObject);
	   }
          
       if(otrer.gameObject.tag == "asteroide"){
        Instantiate (explocion, transform.position, transform.rotation);
	    Destroy(otrer.gameObject);

			puntuacion = GameObject.Find("score");
		puntuacion.SendMessage("incrementarScore");
		
	   }
	   if(otrer.gameObject.tag != "Player"){
	      Destroy(gameObject);
        //  Destroy(otrer.gameObject);
        }

	}

	
}
